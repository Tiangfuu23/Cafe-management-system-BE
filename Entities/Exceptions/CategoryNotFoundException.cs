
namespace Entities.Exceptions
{
    public class CategoryNotFoundException : NotFoundException
    {
        public CategoryNotFoundException(int id) : base($"Category với Id = {id} không tồn tại trong hệ thống")
        {
            
        }
    }
}
