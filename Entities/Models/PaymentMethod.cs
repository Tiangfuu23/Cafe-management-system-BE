using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class PaymentMethod
    {
        [Key]
        [Column("PaymentMethodId")]
        public int id { get; set; }

        [Required(ErrorMessage = "Payment method's description is required")]
        public string? description { get; set; }

        public List<Bill>? Bills { get; set; }
    }
}
