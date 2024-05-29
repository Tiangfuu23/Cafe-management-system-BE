using Contracts;
using Services.Contracts;
using Shared.DataTransferObjects;

namespace Services
{
    internal class DashboardService : IDashboardService
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryManager _repositoryManager;
        public DashboardService(ILoggerManager logger, IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
        }

        public DashboardDto GetDashboard()
        {
            var categoryEntitiesList = _repositoryManager.RepositoryCategory.GetAllCategories(trackChange: false);
            var productEntitiesList = _repositoryManager.RepositoryProduct.GetProducts(trackChange: false); 
            var userEntitiesList = _repositoryManager.RepositoryUser.GetAllUsers(trackchange: false);

            var billEntitiesList = _repositoryManager.RepositoryBill.GetAllBills(trackChange: false);
            var billProductEntitiesList = _repositoryManager.RepositoryBillProduct.GetAllBillProducts(trackChange: false);
            var productEntitiesListList = _repositoryManager.RepositoryProduct.GetProducts(trackChange: false);

            var billForStats = (from bill in billEntitiesList
                                join billProduct in billProductEntitiesList
                                on bill.id equals billProduct.billId
                                join product in productEntitiesList
                                on billProduct.productId equals product.id
                                select new
                                {
                                    product.productName,
                                    bill.creationDate,
                                    product.price,
                                    billProduct.quantity
                                }
                               );
            float revenue = 0;
            foreach(var bill in billForStats)
            {
                revenue += bill.price * bill.quantity;
            }

            var dashBoardDto = new DashboardDto
            {
                categoryCnt = categoryEntitiesList.Count(),
                productCnt = productEntitiesList.Count(),
                revenue = revenue,
                userCnt = userEntitiesList.Count(),
            };
            return dashBoardDto;
        }
    }
}
