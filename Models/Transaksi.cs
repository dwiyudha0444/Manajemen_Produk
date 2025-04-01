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
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        public DateTime TransactionDate { get; set; } = DateTime.Now;

        // Relasi ke Product
        [ForeignKey("ProductId")]
        public Produk Produk { get; set; }
    }
}
