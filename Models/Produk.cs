using System.ComponentModel.DataAnnotations;

namespace Manajemen_Produk.Models
{
    public class Produk
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nama { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public int Harga { get; set; }

        [Required]
        public int Stok { get; set; }
    }
}
