using Shared.DataTransferObjects;

namespace Services.Contracts
{
    public interface IBillService
    {
        (bool, string, int?) CreateBill(BillForCreationDto billForCreation);

        IEnumerable<BillDto> GetAllBills(bool trackChange);

        void DeleteBill(int id);
    }
}
