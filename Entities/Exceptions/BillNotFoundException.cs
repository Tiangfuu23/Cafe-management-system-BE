
namespace Entities.Exceptions
{
    public class BillNotFoundException : NotFoundException
    {
        public BillNotFoundException(int id) : base($"Bill với id = {id} không tồn tại trong hệ thống")
        {
            
        }
    }
}
