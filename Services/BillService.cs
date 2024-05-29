using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Services.Contracts;
using Shared.DataTransferObjects;

// For pdf generation
using iText.Kernel.Pdf;
using iText.Layout.Properties;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.AspNetCore.Hosting;
using iText.Kernel.Pdf.Canvas.Draw;
using System.Globalization;
using iText.IO.Font;
using iText.Kernel.Font;

namespace Services
{
    internal class BillService : IBillService
    {   
        private readonly ILoggerManager _logger;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly string pdfPath;
        private readonly string FONT;
        public BillService(ILoggerManager loginService, IRepositoryManager repository, IMapper mapper, IWebHostEnvironment env)
        {

            _logger = loginService;   
            _repository = repository;
            _mapper = mapper;
            pdfPath = Path.Combine(env.ContentRootPath, "MyStaticFiles", "pdf");
            FONT = Path.Combine(env.ContentRootPath, "MyStaticFiles", "font", "vuArial.ttf");
        }

        public IEnumerable<BillDto> GetAllBills(bool trackChange)
        {
            var billEntitiesList = _repository.RepositoryBill.GetAllBills(trackChange: trackChange);

            var paymenMethodEntitiesList = _repository.RepositoryPaymentMethod.GetAllPaymenthods(trackChange: trackChange);

            var userEntitiesList = _repository.RepositoryUser.GetAllUsers(trackChange);

            var roleEntitiesList = _repository.RepositoryRole.GetAllRoles(trackChange: trackChange);

            var billEntitiesForRes = (from bill in billEntitiesList
                                      join paymentMethod in paymenMethodEntitiesList
                                      on bill.paymentMethodId equals paymentMethod.id
                                      join user in userEntitiesList
                                      on bill.userId equals user.userId
                                      join role in roleEntitiesList
                                      on user.roleId equals role.roleId
                                      orderby bill.id descending
                                      select new Bill 
                                      { 
                                        id = bill.id,
                                        guid = bill.guid,
                                        creationDate = bill.creationDate,
                                        PaymentMethod = new PaymentMethod
                                        {
                                            id = paymentMethod.id,
                                            description = paymentMethod.description,
                                        },
                                        User = new User
                                        {
                                            userId = user.userId,
                                            username = user.username,
                                            fullname = user.fullname,
                                            Role = new Role
                                            {
                                                roleId = user.roleId,
                                                description = role.description
                                            }
                                        }
                                      }
                                     );

            var billDtoList = _mapper.Map<IEnumerable<BillDto>>(billEntitiesForRes);
            foreach(var billDto in billDtoList)
            {
                billDto.productDetails = getProductDetailsByBillId(billDto.id, trackChange: trackChange);
                billDto.totalPrice = billDto.productDetails.Sum(p => p.totalSubPrice);
            }
            return billDtoList;
        }

        public (bool, string, int?) CreateBill(BillForCreationDto billForCreation)
        {
            if (billForCreation.productDetails == null) return (false, "Không có sản phẩm nào được chọn!", null);

            checkProductDetailsList(billForCreation.productDetails);

            var paymentMethodEntity = _repository.RepositoryPaymentMethod.GetPaymentMethod(billForCreation.paymentMethodId, trackChange: false);
            if (paymentMethodEntity == null) throw new PaymentMethodNotFoundException(billForCreation.paymentMethodId);

            var userEntity = _repository.RepositoryUser.GetUser(billForCreation.userId, trackChange: false);
            if(userEntity == null) throw new UserNotFoundException(billForCreation.userId);

            var guid = Guid.NewGuid();

            GeneratePDF(billForCreation, paymentMethodEntity, userEntity, guid);

            var billEntity = _mapper.Map<Bill>(billForCreation);
            billEntity.guid = guid;
            _repository.RepositoryBill.createBill(billEntity);

            _repository.Save();

            foreach (var product in billForCreation.productDetails)
            {
                var billProductEntity = new BillProduct
                {
                    billId = billEntity.id,
                    productId = product.id,
                    quantity = product.quantity
                };
                _repository.RepositoryBillProduct.CreateBillProduct(billProductEntity);
                _repository.Save();
            }

            return (true, "Thêm mới thành công", billEntity.id);
        }

        public void DeleteBill(int id)
        {
            var billEntities = _repository.RepositoryBill.GetBill(id, trackChange: true);
            if (billEntities == null) throw new BillNotFoundException(id);

            FileInfo billPdfFile = new FileInfo(Path.Combine(pdfPath, billEntities.guid + ".pdf"));

            if (billPdfFile.Exists)
            {
                billPdfFile.Delete();
            }

            _repository.RepositoryBill.deleteBill(billEntities);
            _repository.Save();
        }

        private void checkProductDetailsList(IEnumerable<ProductDetailsDto> productDetailsList)
        {
            foreach(var product in productDetailsList)
            {
                var productEnitty = _repository.RepositoryProduct.GetProduct(product.id, trackChange: false);
                if (productEnitty == null) throw new ProductNotFoundException(product.id);
            }
        }

        private IEnumerable<ProductDetailsDto> getProductDetailsByBillId(int billId, bool trackChange)
        {
            var billProdcutEntitiesList = _repository.RepositoryBillProduct.GetAllBillProducts(trackChange);

            var productEntitiesList = _repository.RepositoryProduct.GetProducts(trackChange);

            var categoryEntitiesList = _repository.RepositoryCategory.GetAllCategories(trackChange);

            IEnumerable<ProductDetailsDto> productDetailsList = (from billProduct in billProdcutEntitiesList
                                                                 join product in productEntitiesList
                                                                 on billProduct.productId equals product.id
                                                                 join category in categoryEntitiesList
                                                                 on product.categoryId equals category.id
                                                                 where billProduct.billId == billId
                                                                 select new ProductDetailsDto
                                                                 {
                                                                     id = product.id,
                                                                     productName = product.productName,
                                                                     price = product.price,
                                                                     quantity = billProduct.quantity,
                                                                     categoryName = category.categoryName
                                                                 });

            return productDetailsList;
        }

        public void GeneratePDF(BillForCreationDto bill, PaymentMethod paymentMethod, User creator, Guid guid)
        {
            PdfFont f = PdfFontFactory.CreateFont(FONT, PdfEncodings.IDENTITY_H); // Handle vietnamese-word related errors
            _logger.LogInfo(Path.Combine(pdfPath, guid + ".pdf"));
            //Initialize PDF writer
            PdfWriter writer = new PdfWriter(Path.Combine(pdfPath ,guid + ".pdf"));
            //Initialize PDF document
            PdfDocument pdf = new PdfDocument(writer);
            // Initialize document
            Document document = new Document(pdf);
            
            // Add content to the document
            // Header    
            document.Add(new Paragraph("Cafe Management System")
                    .SetBold()
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(20));

            var ls = new LineSeparator(new SolidLine());
            document.Add(ls);

            // Bill data
            document.Add(new Paragraph($"Creator Name: {creator.fullname}").SetFont(f));
            document.Add(new Paragraph($"Date: {bill.creationDate.ToShortDateString()} {bill.creationDate.ToShortTimeString()}"));
            document.Add(new Paragraph($"Payment Method: {paymentMethod.description}"));

            // Table for invoice items
            Table table = new Table(new float[] { 1, 1, 1, 1, 1});
            table.SetWidth(UnitValue.CreatePercentValue(100));
            table.AddHeaderCell("Category name");
            table.AddHeaderCell("Product Name");
            table.AddHeaderCell("Unit Price");
            table.AddHeaderCell("Quantity");
            table.AddHeaderCell("Total");

            foreach (var product in bill.productDetails!)
            {
                table.AddCell(new Cell().Add(new Paragraph(product.categoryName).SetFont(f)));
                table.AddCell(new Cell().Add(new Paragraph(product.productName).SetFont(f)));
                table.AddCell(new Cell().Add(new Paragraph(product.price.ToString("C", CultureInfo.CurrentCulture))));
                table.AddCell(new Cell().Add(new Paragraph(product.quantity.ToString())));
                table.AddCell(new Cell().Add(new Paragraph(product.totalSubPrice.ToString("C", CultureInfo.CurrentCulture))));
            }

            //Add the Table to the PDF Document
            document.Add(table);

            // Total Amount
            document.Add(new Paragraph($"Total Amount: {bill.totalPrice.ToString("C", CultureInfo.CurrentCulture)}")
                .SetTextAlignment(TextAlignment.RIGHT));

            // Close the Document
            document.Close();
        }

    }
}
