using Entities.Models;
using Entities.DataTransferObjects;
namespace Services.Contracts
{
    public interface IUserService
    {
        public IEnumerable<UserDto> GetAllUsers(bool trackChange);

        public UserDto GetUser(int id, bool trackChange);

        public bool Register(UserForRegistrationDto userForRegistrationDto);

        void UpdatePassword(int userId, PasswordForUpdateDto passwordForUpdateDto);
        //public void Update()

        void UpdateUser(int userId, UserForUpdateDto userForUpdateDto);
    }
}
