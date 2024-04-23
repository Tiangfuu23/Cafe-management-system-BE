

namespace Entities.Exceptions
{
    public class ProductAlreadyExistException : ConflictException
    {
        public ProductAlreadyExistException(string productName) 
            : base($"Tên sản phẩm: {productName} đã tồn tại trong hệ thống!")
        {
            
        }
    }
}
