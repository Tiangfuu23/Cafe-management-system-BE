
using Entities.DataTransferObjects;
using Entities.Models;

namespace Shared.DataTransferObjects
{
    public record BillDto
    {
        public int id { get; set; }
        public Guid guid { get; set; }
        public DateTime creationDate { get; set; }
        public PaymentMethodDto? paymentMethod { get; set; }
        public UserDto? user { get; set; }
        public IEnumerable<ProductDetailsDto>? productDetails { get; set; }

        public float? totalPrice {get; set;}
        } 
 }
