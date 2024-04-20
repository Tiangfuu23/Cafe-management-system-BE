
using Entities.DataTransferObjects;

namespace Services.Contracts
{
    public interface ILoginService
    {
        bool ValidateUSer(UserForAuthenticationDto userForAuth);
        string CreateToken();
    }
}
