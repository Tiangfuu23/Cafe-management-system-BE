using Entities.Models;

namespace Contracts
{
    public interface IRepositoryUser
    {
        IEnumerable<User> GetAllUsers(bool trackchanges);
        User? getUser(string username, bool trackChange);

        User? getUser(int userId, bool trackChange);

        void CreateUser(User user);

        void UpdateUser(User user);
    }
}
