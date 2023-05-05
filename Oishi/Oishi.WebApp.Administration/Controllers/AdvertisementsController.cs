using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oishi.Data.Contexts;

namespace Oishi.WebApp.Administration.Controllers
{
    public class AdvertisementsController : Controller
    {
        private readonly DatabaseContext _context;

        public AdvertisementsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Advertisements
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.Advertisements.Include(a => a.MunicipalityOrCity).Include(a => a.Subcategory).Include(a => a.UserAccount);
            return View(await databaseContext.ToListAsync());
        }

        // GET: Advertisements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Advertisements == null)
            {
                return NotFound();
            }

            var advertisement = await _context.Advertisements
                .Include(a => a.MunicipalityOrCity)
                .Include(a => a.Subcategory)
                .Include(a => a.UserAccount)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (advertisement == null)
            {
                return NotFound();
            }

            return View(advertisement);
        }
    }
}
