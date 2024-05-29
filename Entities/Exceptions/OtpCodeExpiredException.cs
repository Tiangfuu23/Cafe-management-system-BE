

namespace Entities.Exceptions
{
    public class OtpCodeExpiredException : ForBiddenExpcetion
    {
        public OtpCodeExpiredException() : base("Mã OTP đã hết hạn! Vui lòng thử lại")
        {
            
        }
    }
}
