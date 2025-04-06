using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manajemen_Produk.Models
{
    public class Transaksi
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Produk_id { get; set; }

        [Required]
        public int Qty { get; set; }

        [Required]
        public int TotalHarga { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        // Relasi ke Product
        [ForeignKey("Produk_id")]
        public Produk Produk { get; set; }
    }
}
