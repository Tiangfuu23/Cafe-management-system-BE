using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Role
    {
        [Key]
        [Column("RoleId")]
        public int roleId { get; set; }

        [Required(ErrorMessage = "Role's description is required")]
        [Column("Description")]
        [MaxLength(256, ErrorMessage = "Maximum length for description is 256 chars")]
        public string? description { get; set; }


        public ICollection<User>? Users { get; set; }
    }
}
