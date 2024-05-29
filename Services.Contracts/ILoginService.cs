
using Entities.DataTransferObjects;
using Entities.Models;

namespace Services.Contracts
{
    public interface ILoginService
    {
        (UserDto, TokenDto) ValidateUSer(UserForAuthenticationDto userForAuth);
        string CreateToken(User user);
    }
}
