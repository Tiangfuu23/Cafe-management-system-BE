using Entities.Models;
using Entities.DataTransferObjects;
using Shared.DataTransferObjects;
namespace Services.Contracts
{
    public interface IUserService
    {
        public IEnumerable<UserDto> GetAllUsers(bool trackChange);

        public UserDto GetUser(int id, bool trackChange);

        public int Register(UserForRegistrationDto userForRegistrationDto);

        void UpdatePassword(int userId, PasswordForUpdateDto passwordForUpdateDto);

        void UpdateUser(int userId, UserForUpdateDto userForUpdateDto);

    }
}
