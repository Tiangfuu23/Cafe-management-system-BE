
namespace Entities.Exceptions
{
    public class RoleNotFoundException : NotFoundException
    {
        public RoleNotFoundException(int id) : base($"Role với id = {id} không tồn tại trong hệ thống")
        {
            
        }
    }
}
