using Contracts;
using Entities.Models;

namespace Repository
{
    internal class RepositoryBillProduct : RepositoryBase<BillProduct>, IRepositoryBillProduct
    {
        public RepositoryBillProduct(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public void CreateBillProduct(BillProduct billProduct)
        {
            Create(billProduct);
        }

        public IEnumerable<BillProduct> GetAllBillProducts(bool trackChange)
        {
            return FindAll(trackChange).OrderBy(bp => bp.id).ToList();
        }
    }
}
