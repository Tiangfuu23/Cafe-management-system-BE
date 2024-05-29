using Contracts;
using Entities.Models;

namespace Repository
{
    internal class RepositoryPaymentMethod : RepositoryBase<PaymentMethod>, IRepositoryPaymentMethod
    {
        public RepositoryPaymentMethod(RepositoryContext repositoryContext) : base(repositoryContext)
        {
          
        }

        public IEnumerable<PaymentMethod> GetAllPaymenthods(bool trackChange)
        {
            return FindAll(trackChange).OrderBy(p => p.id).ToList();
        }

        public PaymentMethod? GetPaymentMethod(int id, bool trackChange)
        {
            return FindByCondition((p) => p.id == id, trackChange).SingleOrDefault();
        }
    }
}
