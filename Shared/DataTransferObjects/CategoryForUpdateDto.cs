using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record CategoryForUpdateDto
    {
        [Required(ErrorMessage = "Category's id is required")]
        public int id { get; init; }

        [Required(ErrorMessage = "Category's name is required")]
        public string? categoryName { get; init; }
    }
}
