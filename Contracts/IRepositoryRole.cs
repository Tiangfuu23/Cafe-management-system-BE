

using Entities.Models;

namespace Contracts
{
    public interface IRepositoryRole
    {
        IEnumerable<Role> GetAllRoles(bool trackChange);
        Role? GetRole(int roleId, bool trackChange);
    }
}
