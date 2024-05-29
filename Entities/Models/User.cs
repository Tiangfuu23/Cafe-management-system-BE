using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class User
    {
        [Key]
        [Column("UserId")]
        public int userId { get; set; }

        [Required(ErrorMessage = "Fullname is required")]
        [Column("Fullname")]
        [MaxLength(256, ErrorMessage = "Maximum length for user's fullname is 256 chars")]
        public string? fullname { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [Column("Username")]
        [MaxLength(256, ErrorMessage = "Maximum length for user's username is 256 chars")]
        public string? username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Column("Password")]
        [MaxLength(256, ErrorMessage = "Maximum length for user's password is 256 chars")]
        public string? password { get; set; }

        [Required(ErrorMessage = "User's birthday is required")]
        [Column("Birthday")]
        public DateTime? birthday { get; set; }

        [Required(ErrorMessage = "Gender is requered")]
        [Column("Gender")]
        [MaxLength(256, ErrorMessage = "Maximum length for user's gender is 256 chars")]

        public string? gender { get; set; }

        [Required(ErrorMessage = "Email is requered")]
        [Column("Email")]
        [MaxLength(256, ErrorMessage = "Maximum length for user's email is 256 chars")]
        public string? email { get; set; }

        [Column("RoleId")]
        [Required(ErrorMessage = "RoleId is require")]
        public int roleId { get; set; }
        public Role? Role { get; set; }

        public List<Category>? Categories { get; set; }

        public List<Product>? Products { get; set; }

        public List<Bill>? Bills { get; set; }

    }
}
