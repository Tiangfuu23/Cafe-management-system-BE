using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record BillForCreationDto
    {


        [Required(ErrorMessage = "Creation date is required")]
        public DateTime creationDate { get; init; }

        [Required(ErrorMessage = "Creator's id is required")]
        public int userId { get; init; }

        [Required(ErrorMessage = "Payment method id is required")]
        public int paymentMethodId { get; init; }

        public IEnumerable<ProductDetailsDto>? productDetails { get; init; }

        public float totalPrice => productDetails.Sum(product => product.totalSubPrice); 
    }
}
