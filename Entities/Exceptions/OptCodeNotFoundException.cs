

namespace Entities.Exceptions
{
    public class OptCodeNotFoundException : NotFoundException
    {
        public OptCodeNotFoundException(int otpId) : base($"Có lỗi xảy ra! Không thể xác thực OTP ID = {otpId}")
        {
                        
        }
    }
}
