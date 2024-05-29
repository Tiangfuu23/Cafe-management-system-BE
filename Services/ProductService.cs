using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Services.Contracts;
using Shared.DataTransferObjects;

namespace Services
{
    internal class ProductService : IProductService
    {   
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public ProductService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public int CreateProduct(ProductForCreationDto productForCreation)
        {
            // 1. Check Product's name already exist or not
            // 2. Check Category id already exist or not
            // 3. Check User id already exist or not 
            var ProductsEntityList = _repository.RepositoryProduct.GetProducts(trackChange: false);
            foreach(var prod in ProductsEntityList)
            {
                if (prod.productName == productForCreation.productName)
                    throw new ProductAlreadyExistException(productForCreation.productName);
            }
            var categoryEntity = _repository.RepositoryCategory.GetCategory(productForCreation.categoryId, trackChange: false);
            if (categoryEntity == null) throw new CategoryNotFoundException(productForCreation.categoryId);

            var userEntity = _repository.RepositoryUser.GetUser(productForCreation.userId, trackChange: false);
            if (userEntity == null) throw new UserNotFoundException(productForCreation.userId);

            var productEntity = _mapper.Map<Product>(productForCreation);
            _repository.RepositoryProduct.CreateProduct(productEntity);
            _repository.Save();

            return productEntity.id;
        }

        public IEnumerable<ProductDto> GetAllProducts(bool trackChange)
        {
            var categoriesList = _repository.RepositoryCategory.GetAllCategories(trackChange);
            var productsList = _repository.RepositoryProduct.GetProducts(trackChange);
            var userLists = _repository.RepositoryUser.GetAllUsers(trackChange);

            var productsForResponse =  (from product in productsList
                                        join category in categoriesList
                                        on product.categoryId equals category.id 
                                        join user in userLists 
                                        on product.userId equals user.userId
                                        orderby product.id ascending
                                        select new Product
                                        {
                                            id = product.id,
                                            productName = product.productName,
                                            description = product.description,
                                            price = product.price,
                                            active = product.active,
                                            status = product.status,
                                            Category = new Category
                                            {
                                                id = category.id,
                                                categoryName = category.categoryName
                                            },
                                            User = new User
                                            {
                                                fullname = user.fullname,
                                            }
                                        });
            var productsForResponseDto = _mapper.Map<IEnumerable<ProductDto>>(productsForResponse);
            return productsForResponseDto;
        }

        public ProductDto GetProduct(int id, bool trackChange)
        {
            var productEntity = _repository.RepositoryProduct.GetProduct(id, trackChange);
            if (productEntity == null) throw new ProductNotFoundException(id);

            var categoryEntity = _repository.RepositoryCategory.GetCategory(productEntity.categoryId, trackChange);
            if (categoryEntity == null) throw new CategoryNotFoundException(productEntity.categoryId);
            productEntity.Category = categoryEntity;

            var userEntity = _repository.RepositoryUser.GetUser(productEntity.userId, trackChange);
            if (userEntity == null) throw new UserNotFoundException(productEntity.userId);
            productEntity.User = userEntity;

            var productDto = _mapper.Map<ProductDto>(productEntity); 
            return productDto;
        }

        public void UpdateProduct(ProductForUpdateDto productForUpdateDto)
        {

            var productEntity = _repository.RepositoryProduct.GetProduct(productForUpdateDto.id, trackChange: true);
            if (productEntity == null) throw new ProductNotFoundException(productForUpdateDto.id);

            var categoryEntity = _repository.RepositoryCategory.GetCategory(productForUpdateDto.categoryId, trackChange: false);
            if (categoryEntity == null) throw new CategoryNotFoundException(productForUpdateDto.categoryId);
            
            _mapper.Map(productForUpdateDto, productEntity);
            _repository.Save();
        }

        public void DeleteProduct(int id)
        {
            var productEntity = _repository.RepositoryProduct.GetProduct(id, trackChange: true);
            if (productEntity == null) throw new ProductNotFoundException(id);

            _repository.RepositoryProduct.DeleteProduct(productEntity);
            _repository.Save();
        }

        public void UpdateProductStatus(int id, bool newStatus)
        {
            var productEntity = _repository.RepositoryProduct.GetProduct(id, trackChange: true);
            if (productEntity == null) throw new ProductNotFoundException(id);

            productEntity.active = newStatus;
            _repository.Save();
        }
    }
}