using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevsonMotors.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        [Required]
        public int OrderTotal { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
