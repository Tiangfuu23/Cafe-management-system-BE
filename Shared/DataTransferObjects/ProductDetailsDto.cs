using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record ProductDetailsDto
    {
        [Required(ErrorMessage = "Product's id is required")]
        public int id { get; init; }

        [Required(ErrorMessage = "Product's name is required")]
        public string? productName { get; init; }

        [Required(ErrorMessage = "Product's price is required")]
        public float price { get; init; }

        [Required(ErrorMessage = "Product's quantity is required")]
        public int quantity { get; init; }

        [Required(ErrorMessage = "Product's Category name is requred")]
        public string? categoryName { get; init; }

        public float totalSubPrice => price * quantity;
    }
}
