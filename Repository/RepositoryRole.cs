
using Contracts;
using Entities.Models;

namespace Repository
{
    internal class RepositoryRole : RepositoryBase<Role> ,IRepositoryRole
    {
        public RepositoryRole(RepositoryContext repositoryContext) : base(repositoryContext)
        { }

        public IEnumerable<Role> GetAllRoles(bool trackChanges)
        {
            return FindAll(trackChanges);
        }

        public Role? GetRole(int roleId, bool trackChange)
        {
            return FindByCondition(role => role.roleId == roleId, trackChange).SingleOrDefault();
        }
    }
}
