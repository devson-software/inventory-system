using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevsonMotors.Models
{
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? SupplierId { get; set; }
        [Required]
        public string? SupplierName { get; set; }
        public string? ContactPerson { get; set; }
        [Required]
        public string? Phone {get; set; }
        [Required]
        public string? Email { get; set; }
    }
}
