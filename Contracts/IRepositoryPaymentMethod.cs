using Entities.Models;

namespace Contracts
{
    public interface IRepositoryPaymentMethod
    {
        IEnumerable<PaymentMethod> GetAllPaymenthods(bool trackChange);

        PaymentMethod? GetPaymentMethod(int id, bool trackChange);
    }
}
