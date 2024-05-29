namespace Entities.Exceptions
{
    public class PaymentMethodNotFoundException : NotFoundException
    {
        public PaymentMethodNotFoundException(int paymentMethodId) 
            : base($"Payment method với id = {paymentMethodId} không tồn tại trong hệ thống!")
        {
            
        }
    }
}
