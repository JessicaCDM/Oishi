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
    public class UserAccountsController : Controller
    {
        private readonly DatabaseContext _context;

        public UserAccountsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: UserAccounts
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.UserAccounts.Include(u => u.Profile);
            return View(await databaseContext.ToListAsync());
        }

        // GET: UserAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserAccounts == null)
            {
                return NotFound();
            }

            var userAccount = await _context.UserAccounts
                .Include(u => u.Profile)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userAccount == null)
            {
                return NotFound();
            }

            return View(userAccount);
        }

        // GET: UserAccounts/Create
        public IActionResult Create()
        {
            ViewData["ProfileId"] = new SelectList(_context.Profiles, "Id", "Code");
            return View();
        }

        // POST: UserAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Email,Phone,BirthDate,LastLogin,SourceImage,DateCreated,UserAccountStatus,ProfileId")] UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProfileId"] = new SelectList(_context.Profiles, "Id", "Code", userAccount.ProfileId);
            return View(userAccount);
        }

        // GET: UserAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserAccounts == null)
            {
                return NotFound();
            }

            var userAccount = await _context.UserAccounts.FindAsync(id);
            if (userAccount == null)
            {
                return NotFound();
            }
            ViewData["ProfileId"] = new SelectList(_context.Profiles, "Id", "Code", userAccount.ProfileId);
            return View(userAccount);
        }

        // POST: UserAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Email,Phone,BirthDate,LastLogin,SourceImage,DateCreated,UserAccountStatus,ProfileId")] UserAccount userAccount)
        {
            if (id != userAccount.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserAccountExists(userAccount.Id))
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
            ViewData["ProfileId"] = new SelectList(_context.Profiles, "Id", "Code", userAccount.ProfileId);
            return View(userAccount);
        }

        // GET: UserAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserAccounts == null)
            {
                return NotFound();
            }

            var userAccount = await _context.UserAccounts
                .Include(u => u.Profile)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userAccount == null)
            {
                return NotFound();
            }

            return View(userAccount);
        }

        // POST: UserAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserAccounts == null)
            {
                return Problem("Entity set 'DatabaseContext.UserAccounts'  is null.");
            }
            var userAccount = await _context.UserAccounts.FindAsync(id);
            if (userAccount != null)
            {
                _context.UserAccounts.Remove(userAccount);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserAccountExists(int id)
        {
          return (_context.UserAccounts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
