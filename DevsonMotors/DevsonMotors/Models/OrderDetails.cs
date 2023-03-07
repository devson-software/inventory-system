using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace DevsonMotors.Models
{
    public class OrderDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? OrderDetailsId { get; set; }
        [ForeignKey("Order")]
        public int? OrderId { get; set; }
        [ForeignKey("Product")]
        public int? ProductId { get; set; }
        [Required]
        public int? QuatityOrdered { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
   }
}
