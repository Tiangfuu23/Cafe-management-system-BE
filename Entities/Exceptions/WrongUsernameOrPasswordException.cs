

using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities.Exceptions
{
    public class WrongUsernameOrPasswordException : ConflictException
    {
        public WrongUsernameOrPasswordException() : base("Sai tên đăng nhập hoặc mật khẩu!")
        {
            
        }

        public WrongUsernameOrPasswordException(bool isIncorrectUsername, bool isIncorrectPassword) 
            : base($"{(isIncorrectUsername ? "Tên đăng nhập" : "Mật khẩu")} không chính xác! Vui lòng kiểm tra lại.")
        {

        }
    }
}
