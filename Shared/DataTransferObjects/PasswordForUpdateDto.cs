
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public record PasswordForUpdateDto
    {
        [Required(ErrorMessage = "User's Id is required")]
        public int userId { get; set; }

        //[Required(ErrorMessage = "Old password is required")]
        public string? oldPassword { get; init; }

        [Required(ErrorMessage = "New password is required")]
        public string newPassword { get; init; }

    }
}
