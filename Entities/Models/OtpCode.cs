using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class OtpCode
    {
        [Key]
        [Column("OtpCodeId")]
        public int id { get; set; }

        [Required(ErrorMessage = "OTP Code is required")]
        [Column("Code")]
        [MinLength(5,ErrorMessage = "OTP Code's Minimum length is 5")]
        [MaxLength(5, ErrorMessage = "OTP Code's Maximum length is 5")]
        public string code { get; set; }

        [Required(ErrorMessage = "Creation Date is required")]
        [Column("CreationDate")]
        public DateTime creationDate { get; set; }

        //[Required(ErrorMessage = "Attempts Cnt is required")]
        [DefaultValue(0)]
        [Column("AttempsCnt")]
        public int attempsCnt { get; set; }

        [DefaultValue(true)]
        [Column("Used")]
        public Boolean used{ get; set; }

        [Required(ErrorMessage = "User'id is required")]
        [Column("UserId")]
        public int userId { get; set; }


        public User? User { get; set; }
    }
}
