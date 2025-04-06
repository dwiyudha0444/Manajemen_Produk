using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Manajemen_Produk.Models;
using Manajemen_Produk.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Manajemen_Produk.Controllers
{
    [Route("transaksi")]
    public class TransaksiController : Controller
    {
        private readonly AppDbContext _context;

        public TransaksiController(AppDbContext context)
        {
            _context = context;
        }

        [Route("")]
        public async Task<IActionResult> Index()
        {
            var transaksi = await _context.Transaksi.ToListAsync();
            return View(transaksi);
        }

        // Menampilkan Form Create
        [HttpGet]
        [Route("tambah")] // URL: /transaksi/tambah
        public IActionResult Create()
        {
            // Kirim daftar produk ke View
            ViewBag.ProdukList = new SelectList(_context.Produk, "Id", "Nama");
            return View();
        }

        // Menyimpan Data ke Database
        [HttpPost]
        [Route("tambah")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Produk_id,Qty,TotalHarga,Date")] Transaksi transaksi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaksi);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            // Jika gagal, kirim ulang daftar produk
            ViewBag.ProdukList = new SelectList(_context.Produk, "Id", "Nama");
            return View(transaksi);
        }


        // Konfirmasi Hapus Transaksi
        [HttpGet]
        [Route("hapus/{id}")] // URL: /transaksi/hapus/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var transaksi = await _context.Transaksi.FindAsync(id);
            if (transaksi == null)
            {
                return NotFound();
            }
            return View(transaksi); // Menampilkan konfirmasi penghapusan
        }

        // Proses Hapus Transaksi
        [HttpPost, ActionName("Delete")]
        [Route("hapus/{id}")]
        [ValidateAntiForgeryToken] // Mencegah serangan CSRF
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaksi = await _context.Transaksi.FindAsync(id);
            if (transaksi != null)
            {
                _context.Transaksi.Remove(transaksi); // Hapus transaksi dari database
                await _context.SaveChangesAsync(); // Simpan perubahan
            }
            return RedirectToAction("Index"); // Kembali ke daftar transaksi
        }

        // GET: Product/Edit/5
        [HttpGet]
        [Route("Transaksi/Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var transaksi = await _context.Transaksi.FindAsync(id);
            if (transaksi == null)
            {
                return NotFound();
            }
            return View(transaksi);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [Route("Transaksi/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Nama, Harga")] Transaksi transaksi)
        {
            if (id != transaksi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaksi);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(transaksi.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(transaksi);
        }

        [HttpGet]
        [Route("detail/{id}")]

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaksi = await _context.Transaksi.FirstOrDefaultAsync(p => p.Id == id);

            if (transaksi == null)
            {
                return NotFound();
            }

            return View(transaksi); // ← Kirim satu objek Transaksi
        }



        private bool ProductExists(int id)
        {
            return _context.Transaksi.Any(e => e.Id == id);
        }

    }

}