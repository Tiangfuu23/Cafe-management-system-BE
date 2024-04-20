namespace Entities.Exceptions
{
    public class UsernameExistException : ConflictException
    {
        public UsernameExistException(string username) : base($"Tên người dùng {username} đã tồn tại!")
        {
            
        }
    }
}
