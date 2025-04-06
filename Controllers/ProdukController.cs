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
    }
}

