using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Oishi.Data.Contexts;
using Oishi.Data.Models;

namespace Oishi.WebApp.Administration.Controllers
{
    public class MunicipalityOrCitiesController : Controller
    {
        private readonly DatabaseContext _context;

        public MunicipalityOrCitiesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: MunicipalityOrCities
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.MunicipalityOrCities.Include(m => m.Region);
            return View(await databaseContext.ToListAsync());
        }

        // GET: MunicipalityOrCities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MunicipalityOrCities == null)
            {
                return NotFound();
            }

            var municipalityOrCity = await _context.MunicipalityOrCities
                .Include(m => m.Region)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (municipalityOrCity == null)
            {
                return NotFound();
            }

            return View(municipalityOrCity);
        }

        // GET: MunicipalityOrCities/Create
        public IActionResult Create()
        {
            ViewData["RegionId"] = new SelectList(_context.Regions, "Id", "Name");
            return View();
        }

        // POST: MunicipalityOrCities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,RegionId")] MunicipalityOrCity municipalityOrCity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(municipalityOrCity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RegionId"] = new SelectList(_context.Regions, "Id", "Name", municipalityOrCity.RegionId);
            return View(municipalityOrCity);
        }

        // GET: MunicipalityOrCities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MunicipalityOrCities == null)
            {
                return NotFound();
            }

            var municipalityOrCity = await _context.MunicipalityOrCities.FindAsync(id);
            if (municipalityOrCity == null)
            {
                return NotFound();
            }
            ViewData["RegionId"] = new SelectList(_context.Regions, "Id", "Name", municipalityOrCity.RegionId);
            return View(municipalityOrCity);
        }

        // POST: MunicipalityOrCities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,RegionId")] MunicipalityOrCity municipalityOrCity)
        {
            if (id != municipalityOrCity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(municipalityOrCity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MunicipalityOrCityExists(municipalityOrCity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["RegionId"] = new SelectList(_context.Regions, "Id", "Name", municipalityOrCity.RegionId);
            return View(municipalityOrCity);
        }

        // GET: MunicipalityOrCities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MunicipalityOrCities == null)
            {
                return NotFound();
            }

            var municipalityOrCity = await _context.MunicipalityOrCities
                .Include(m => m.Region)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (municipalityOrCity == null)
            {
                return NotFound();
            }

            return View(municipalityOrCity);
        }

        // POST: MunicipalityOrCities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MunicipalityOrCities == null)
            {
                return Problem("Entity set 'DatabaseContext.MunicipalityOrCities'  is null.");
            }
            var municipalityOrCity = await _context.MunicipalityOrCities.FindAsync(id);
            if (municipalityOrCity != null)
            {
                _context.MunicipalityOrCities.Remove(municipalityOrCity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MunicipalityOrCityExists(int id)
        {
          return (_context.MunicipalityOrCities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
