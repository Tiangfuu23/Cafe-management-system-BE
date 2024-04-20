using Entities.Models;
using Entities.DataTransferObjects;
namespace Services.Contracts
{
    public interface IUserService
    {
        public IEnumerable<UserDto> GetAllUsers();
        public bool Register(UserForRegistrationDto userForRegistrationDto);

        void UpdatePassword(int userId, PasswordForUpdateDto passwordForUpdateDto);
        //public void Update()

        void UpdateUser(int userId, UserForUpdateDto userForUpdateDto);
    }
}
