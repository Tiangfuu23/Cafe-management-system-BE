using Entities.Models;

namespace Contracts
{
    public interface IRepositoryUser
    {
        IEnumerable<User> GetAllUsers(bool trackchange);
        User? GetUser(string username, bool trackChange);

        User? GetUser(int userId, bool trackChange);

        void CreateUser(User user);

        void UpdateUser(User user);
    }
}
