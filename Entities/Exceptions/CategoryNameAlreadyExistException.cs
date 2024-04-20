namespace Entities.Exceptions
{
    public class CategoryNameAlreadyExistException : ConflictException
    {
        public CategoryNameAlreadyExistException(string categoryName) : base($"Tên category: {categoryName} đã tồn tại trong hệ thống") 
        {
            
        }
    }
}
