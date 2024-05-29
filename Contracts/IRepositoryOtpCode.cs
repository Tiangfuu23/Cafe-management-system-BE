

using Entities.Models;

namespace Contracts
{
    public interface IRepositoryOtpCode
    {
        OtpCode?  getOtpCode(int otpCodeId, bool trackChange);

        void CreateOtpCode(OtpCode otpCode);

        IEnumerable<OtpCode> getOtpCodeByUserId(int userId, bool trackChange);
    }
}
