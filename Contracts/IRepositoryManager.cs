namespace Contracts
{
    public interface IRepositoryManager
    {
        IRepositoryUser RepositoryUser { get; }

        IRepositoryRole RepositoryRole { get; }

        IRepositoryCategory RepositoryCategory { get; }

        IRepositoryProduct RepositoryProduct{get; }

        IRepositoryPaymentMethod RepositoryPaymentMethod { get; }

        IRepositoryBill RepositoryBill { get; }

        IRepositoryBillProduct RepositoryBillProduct { get; }

        IRepositoryOtpCode RepositoryOtpCode { get; }
        void Save();
    }
}
