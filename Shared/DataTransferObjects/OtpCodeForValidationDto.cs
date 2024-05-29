using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.DataTransferObjects
{
    public record OtpCodeForValidationDto
    {
        [Required(ErrorMessage = "Otp code' id is required")]
        public int otpCodeId { get; init; }

        [Required(ErrorMessage = "OTP Code is required")]
        [Column("Code")]
        [MinLength(5, ErrorMessage = "OTP Code's Minimum length is 5")]
        [MaxLength(5, ErrorMessage = "OTP Code's Maximum length is 5")]
        public string? code { get; init; }

    }
}
