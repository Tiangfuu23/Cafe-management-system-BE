using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Product
    {
        [Key]
        [Column("ProductID")]
        public int id { get; set; }

        [Required(ErrorMessage = "Product's name is required")]
        [Column("ProductName")]
        [MaxLength(256, ErrorMessage = "Maximum length for product's name is 256 chars")]
        public string? productName { get; set; }

        [Column("Description")]
        public string? description { get; set; }

        [Required(ErrorMessage = "Price of product is required")]
        [Column("Price")]
        public float price { get; set; }

        [Required(ErrorMessage = "Product's status is required")]
        [Column("Status")]
        public bool status { get; set; }

        [Required(ErrorMessage = "User id is required")]
        [Column("UserId")]
        public int userId { get; set; }

        public User? User { get; set; }

        [Required(ErrorMessage = "Category Id is required")]
        [Column("CategoryId")]
        public int categoryId { get; set; }

        public Category? Category { get; set; }


    }
}
