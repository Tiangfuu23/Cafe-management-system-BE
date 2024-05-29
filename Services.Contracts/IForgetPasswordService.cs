using Entities.DataTransferObjects;
using Entities.Models;
using Shared.DataTransferObjects;

namespace Services.Contracts
{
    public interface IForgetPasswordService
    {
        int handleForgetPassword(ForgetPasswordDto forgetPassword);

        User authenticateOtpCode(OtpCodeForValidationDto optCodeForValidDto);
    }
}
