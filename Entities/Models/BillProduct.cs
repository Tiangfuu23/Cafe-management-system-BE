using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class BillProduct
    {
        [Key]
        [Column("Id")]
        public int id { get; set; }

        [Required(ErrorMessage = "Bill id is required in tbl BillProduct")]
        [Column("BillId")]
        public int billId { get; set; }

        [Required(ErrorMessage = "Product id is required in tbl BillProduct")]
        [Column("ProductId")]
        public int productId { get; set; }

        [Required(ErrorMessage = "Quanity field is required in tbl BillProduct")]
        [Column("Quantity")]
        public int quantity { get; set; }

        public Bill? bill { get; set; }
        public Product? Product { get; set; }

        // Not mapped property
        [NotMapped]
        public float total { get; set; }
    }
}
