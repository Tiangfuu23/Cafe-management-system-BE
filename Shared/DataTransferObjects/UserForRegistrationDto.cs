

using Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public record UserForRegistrationDto
    {
        [Required(ErrorMessage = "Fullname is required")]
        public string? fullname { get; init; }

        [Required(ErrorMessage = "Username is required")]
        public string? username { get; init; }

        [Required(ErrorMessage = "Password is required")]
        public string? password { get; init; }

        [Required(ErrorMessage = "Email is required")]
        public string? email { get; init; }

        [Required(ErrorMessage = "Gender is required")]
        public string? gender { get; init; }


        [Required(ErrorMessage = "Birthday is required")]
        public DateTime? birthday { get; init; }

        [Required(ErrorMessage = "Role Id is required")]
        public int roleId { get; init; }


    }
}
