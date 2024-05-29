using Contracts;
using Entities.Models;

namespace Repository
{
    internal class RepositoryBill : RepositoryBase<Bill>, IRepositoryBill
    {
        public RepositoryBill(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }

        public void createBill(Bill bill)
        {
            Create(bill);
        }

        public void deleteBill(Bill bill)
        {
            Delete(bill);
        }

        public IEnumerable<Bill> GetAllBills(bool trackChange)
        {
            return FindAll(trackChange).OrderBy(bill => bill.id).ToList();
        }

        public Bill? GetBill(int id, bool trackChange)
        {
            return FindByCondition(bill => bill.id == id, trackChange).SingleOrDefault();
        }

        public void updateBill(Bill bill)
        {
            Update(bill);
        }
    }
}
