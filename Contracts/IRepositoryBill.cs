using Entities.Models;

namespace Contracts
{
    public interface IRepositoryBill
    {
        IEnumerable<Bill> GetAllBills(bool trackChange);
        Bill? GetBill(int id, bool trackChange);

        void createBill(Bill bill);

        void updateBill(Bill bill); 

        void deleteBill(Bill bill);
    }
}
