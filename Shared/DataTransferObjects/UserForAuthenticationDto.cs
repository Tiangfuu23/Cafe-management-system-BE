using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public record UserForAuthenticationDto
    {
        [Required(ErrorMessage = "Username is required")]
        public string? username { get; init; }

        [Required(ErrorMessage = "Password is required")]

        public string? password { get; init; } 




    }
}
