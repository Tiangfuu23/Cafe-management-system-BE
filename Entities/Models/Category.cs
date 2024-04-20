
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Category
    {
        [Key]
        [Column("CategoryId")]
        public int id { get; set; }

        [Required(ErrorMessage = "Category name is required")]
        [Column("CategoryName")]
        [MaxLength(256, ErrorMessage = "Maximum length for categery name is 256 chars")]
        public string? categoryName { get; set; }

        [Column("UserId")]
        [Required(ErrorMessage = "Foreign key: userId is required")]
        public int userId { get; set; }
        public User? User { get; set; }
    }
}
