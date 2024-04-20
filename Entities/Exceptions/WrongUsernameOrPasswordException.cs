

namespace Entities.Exceptions
{
    public class WrongUsernameOrPasswordException : UnauthorizedException
    {
        public WrongUsernameOrPasswordException() : base("Sai tên đăng nhập hoặc mật khẩu!")
        {
            
        }

        public WrongUsernameOrPasswordException(bool isWrongPassword) : base("Mật khẩu không đúng!")
        {

        }
    }
}
