using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Manajemen_Produk.Models;
using Manajemen_Produk.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Manajemen_Produk.Controllers
{

    [Route("produk")]
    public class ProdukController : Controller
    {
        private readonly AppDbContext _context;

        public ProdukController(AppDbContext context)
        {
            _context = context;
        }

        [Route("")]
        public async Task<IActionResult> Index()
        {
            var produk = await _context.Produk.ToListAsync();
            return View(produk);
        }

         // Menampilkan Form Create
        [HttpGet]
        [Route("tambah")] // URL: /produk/tambah
        public IActionResult Create()
        {
            return View();
        }

        // Menyimpan Data ke Database
        [HttpPost]
        [Route("tambah")]
        [ValidateAntiForgeryToken] // Mencegah serangan CSRF
        public async Task<IActionResult> Create([Bind("Nama,Harga")] Produk produk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produk); // Tambahkan ke database
                await _context.SaveChangesAsync(); // Simpan perubahan
                return RedirectToAction("Index"); // Kembali ke daftar produk
            }
            return View(produk);
        }

    }
}

