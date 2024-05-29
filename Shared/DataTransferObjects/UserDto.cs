using Entities.Models;

namespace Entities.DataTransferObjects
{
    public record UserDto(int id, string fullname, string username, string email, string gender, DateTime birthday ,RoleDto role);
}
