using Entities.DataTransferObjects;
using Entities.MessageDetail;

namespace Services.Contracts
{
    public interface IForgetPasswordService
    {
        bool handleForgetPassword(ForgetPasswordDto forgetPassword);
    }
}
