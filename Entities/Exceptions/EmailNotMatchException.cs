namespace Entities.Exceptions
{
    public class EmailNotMatchException : ConflictException
    {
        public EmailNotMatchException(string username) : base($"Email đăng ký không khớp với tài khoản {username}!")
        {
            
        }
    }
}
