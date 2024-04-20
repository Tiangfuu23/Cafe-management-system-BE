
namespace Entities.Exceptions
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(string username) : base($"Người dùng {username} không tồn tại trong hệ thống!")
        {
            
        }

        public UserNotFoundException(int userId) : base($"Người dùng với ID {userId} không tồn tại trong hệ thống!") 
        {
            
        }
    }
}
