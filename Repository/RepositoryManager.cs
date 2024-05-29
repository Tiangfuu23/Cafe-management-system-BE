using Contracts;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IRepositoryUser> _repositoryUser;
        private readonly Lazy<IRepositoryRole> _repositoryRole;
        private readonly Lazy<IRepositoryCategory> _repositoryCategory;
        private readonly Lazy<IRepositoryProduct> _repositoryProduct;
        private readonly Lazy<IRepositoryPaymentMethod> _repositoryPaymentMethod;
        private readonly Lazy<IRepositoryBill> _repositoryBill;
        private readonly Lazy<IRepositoryBillProduct> _repositoryBillProduct;
        private readonly Lazy<IRepositoryOtpCode> _repositoryOtpCode;
        public RepositoryManager(RepositoryContext repositoryContext)
        {

            _repositoryContext = repositoryContext;
            _repositoryUser = new Lazy<IRepositoryUser>(() =>  new RepositoryUser(_repositoryContext));
            _repositoryRole = new Lazy<IRepositoryRole>(() => new RepositoryRole(_repositoryContext));
            _repositoryCategory = new Lazy<IRepositoryCategory>(() => new RepositoryCategory(_repositoryContext));
            _repositoryProduct = new Lazy<IRepositoryProduct>(() => new RepositoryProduct(_repositoryContext));
            _repositoryPaymentMethod = new Lazy<IRepositoryPaymentMethod>(() => new RepositoryPaymentMethod(_repositoryContext));
            _repositoryBill = new Lazy<IRepositoryBill>(() => new RepositoryBill(_repositoryContext));
            _repositoryBillProduct = new Lazy<IRepositoryBillProduct>(() => new RepositoryBillProduct(_repositoryContext));
            _repositoryOtpCode = new Lazy<IRepositoryOtpCode>(() => new RepositoryOtpCode(_repositoryContext));
        }

        public IRepositoryUser RepositoryUser => _repositoryUser.Value;

        public IRepositoryRole RepositoryRole => _repositoryRole.Value;

        public IRepositoryCategory RepositoryCategory => _repositoryCategory.Value;

        public IRepositoryProduct RepositoryProduct => _repositoryProduct.Value;

        public IRepositoryPaymentMethod RepositoryPaymentMethod => _repositoryPaymentMethod.Value;

        public IRepositoryBill RepositoryBill => _repositoryBill.Value;

        public IRepositoryBillProduct RepositoryBillProduct => _repositoryBillProduct.Value;

        public IRepositoryOtpCode RepositoryOtpCode => _repositoryOtpCode.Value;
        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
