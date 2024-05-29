

namespace Entities.Exceptions
{
    public class IncorrectOtpCodeException : UnauthorizedException
    {
        public IncorrectOtpCodeException() : base("Mã OTP không chính xác! Vui lòng thử lại.")
        {
            
        }
    }
}
