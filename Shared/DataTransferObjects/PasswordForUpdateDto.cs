
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public record PasswordForUpdateDto
    {

        [Required(ErrorMessage = "Old password is required")]
        public string OldPassword { get; init; }

        [Required(ErrorMessage = "New password is required")]
        public string NewPasswrod { get; init; }

    }
}
