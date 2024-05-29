
using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record ProductForUpdateDto
    {
        [Required(ErrorMessage = "Product's id is requred")]
        public int id { get; init; }

        [Required(ErrorMessage = "Product's name is required")]
        [MaxLength(256, ErrorMessage = "Maximum length for product's name is 256 chars")]
        public string? productName { get; init; }

        public string? description { get; init; }

        [Required(ErrorMessage = "Price of product is required")]
        public float price { get; init; }

        [Required(ErrorMessage = "Product's status is required")]
        public int status { get; init; }

        [Required(ErrorMessage = "Product's active field is required")]
        public Boolean active { get; init; }

        [Required(ErrorMessage = "Category Id is required")]
        public int categoryId { get; init; }
    }
}
