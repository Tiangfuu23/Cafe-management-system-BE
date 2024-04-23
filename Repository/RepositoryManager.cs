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
        public RepositoryManager(RepositoryContext repositoryContext)
        {

            _repositoryContext = repositoryContext;
            _repositoryUser = new Lazy<IRepositoryUser>(() =>  new RepositoryUser(_repositoryContext));
            _repositoryRole = new Lazy<IRepositoryRole>(() => new RepositoryRole(_repositoryContext));
            _repositoryCategory = new Lazy<IRepositoryCategory>(() => new RepositoryCategory(_repositoryContext));
            _repositoryProduct = new Lazy<IRepositoryProduct>(() => new RepositoryProduct(_repositoryContext));
        }

        public IRepositoryUser RepositoryUser => _repositoryUser.Value;

        public IRepositoryRole RepositoryRole => _repositoryRole.Value;

        public IRepositoryCategory RepositoryCategory => _repositoryCategory.Value;

        public IRepositoryProduct RepositoryProduct => _repositoryProduct.Value;

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
