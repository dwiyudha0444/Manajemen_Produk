using System.ComponentModel.DataAnnotations;

namespace Manajemen_Produk.Models
{
    public class Produk
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public int Stock { get; set; }
    }
}
