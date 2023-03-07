using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevsonMotors.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int?  ProductId { get; set; }
        [Required]
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        [Required]
        public decimal? Price { get; set; }
        [Required]
        public int? QuintityInStock { get; set; }

    }
}
