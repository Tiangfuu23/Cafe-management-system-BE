namespace Entities.Exceptions
{
    public class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException(int id) : base($"Product với id = {id} không tồn tại trong hệ thống!")
        {
            
        }
    }
}
