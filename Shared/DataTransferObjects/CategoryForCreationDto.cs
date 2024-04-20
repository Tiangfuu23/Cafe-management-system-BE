

using Entities.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public class CategoryForCreationDto
    {

        [Required(ErrorMessage = "Category name is required")]
        [MaxLength(ErrorMessage = "Maximum length for categery name is 256 chars")]
        public string? categoryName { get; init; }

        [Required(ErrorMessage = "UserId is required")]
        public int userId { get; init; }
    }
}
