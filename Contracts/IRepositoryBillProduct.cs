
using Entities.Models;

namespace Contracts
{
    public interface IRepositoryBillProduct
    {
        IEnumerable<BillProduct> GetAllBillProducts(bool trackChange);

        void CreateBillProduct(BillProduct billProduct);
    }
}
