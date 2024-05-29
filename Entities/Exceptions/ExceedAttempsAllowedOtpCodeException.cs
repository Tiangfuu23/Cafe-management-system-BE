
namespace Entities.Exceptions
{
    public class ExceedAttempsAllowedOtpCodeException : ForBiddenExpcetion
    {
        public ExceedAttempsAllowedOtpCodeException() : base("Mã OTP hết hạn do vượt quá số lần thử đã vượt quá số lần cho phép!")
        {
            
        }
    }
}
