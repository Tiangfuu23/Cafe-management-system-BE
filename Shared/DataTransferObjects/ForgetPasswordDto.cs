
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public record ForgetPasswordDto
    {
        [Required(ErrorMessage = "Username is required")]
        public string username { get; init; }

        [Required(ErrorMessage = "Email is required")]
        public string email { get; init; }
    }
}
