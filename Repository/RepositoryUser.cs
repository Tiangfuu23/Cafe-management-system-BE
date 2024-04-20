
using Contracts;
using Entities.Models;

namespace Repository
{
    internal class RepositoryUser : RepositoryBase<User>, IRepositoryUser
    {
        public RepositoryUser(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<User> GetAllUsers(bool trackchanges) 
        {
            return FindAll(trackchanges).OrderBy(u => u.userId).ToList();        
        }    

        public void CreateUser(User user)
        {
            Create(user);
        }

        public User? getUser(string username, bool trackchange)
        {
            return FindByCondition(u => u.username == username, trackchange).SingleOrDefault();
        }

        public User? getUser(int userId, bool trackChange)
        {
            return FindByCondition(u => u.userId == userId, trackChange).SingleOrDefault();
        }

        public void UpdateUser(User user)
        {
            Update(user);
        }
    }
}
