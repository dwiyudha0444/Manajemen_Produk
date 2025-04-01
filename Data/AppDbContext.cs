using Microsoft.EntityFrameworkCore;
using Manajemen_Produk.Models;

namespace Manajemen_Produk.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produk> Produk { get; set; }
        public DbSet<Transaksi> Transaksi { get; set; }
    }
}
