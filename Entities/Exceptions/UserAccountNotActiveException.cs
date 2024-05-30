

namespace Entities.Exceptions
{
    public class UserAccountNotActiveException : UnauthorizedException 
    {
        public UserAccountNotActiveException() : base("Tài khoản chưa được kích hoạt!")
        {
            
        }
    }
}
