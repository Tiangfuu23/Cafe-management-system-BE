using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Bill
    {
        [Key]
        [Column("BillId")]
        public int id { get; set; }

        [Column("Guid")]
        [Required(ErrorMessage = "Bill's guid is required")] // <- pdf's filename
        public Guid guid { get; set; }

        [Column("CreationDate")]
        [Required(ErrorMessage = "Bill's Creation Date is required")]
        public DateTime creationDate { get; set; }

        [Column("PaymentMethodId")]
        [Required(ErrorMessage = "Bill's Payment method id is required")]
        public int paymentMethodId { get; set; }

        public PaymentMethod? PaymentMethod { get; set; }

        [Column("UserId")]
        [Required(ErrorMessage = "Bill's User id is required")]
        public int userId { get; set; }

        public User? User { get; set; }

        public List<BillProduct>? BillProducts { get; set; }

        // Not map property
        [NotMapped]
        public float total { get; set; }
    }
}
