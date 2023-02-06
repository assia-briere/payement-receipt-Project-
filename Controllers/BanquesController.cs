using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecuPj.Models;

namespace RecuPj.Controllers
{
    public class BanquesController : Controller
    {
        private readonly RecuDbContext _context;

        public BanquesController(RecuDbContext context)
        {
            _context = context;
        }

        // GET: Banques
        public async Task<IActionResult> Index()
        {
              return View(await _context.Banques.ToListAsync());
        }

        // GET: Banques/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Banques == null)
            {
                return NotFound();
            }

            var banque = await _context.Banques
                .FirstOrDefaultAsync(m => m.Na == id);
            if (banque == null)
            {
                return NotFound();
            }

            return View(banque);
        }

        // GET: Banques/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Banques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Na,Nom,DateCreation")] Banque banque)
        {
            if (ModelState.IsValid)
            {
                _context.Add(banque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(banque);
        }

        // GET: Banques/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Banques == null)
            {
                return NotFound();
            }

            var banque = await _context.Banques.FindAsync(id);
            if (banque == null)
            {
                return NotFound();
            }
            return View(banque);
        }

        // POST: Banques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Na,Nom,DateCreation")] Banque banque)
        {
            if (id != banque.Na)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(banque);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BanqueExists(banque.Na))
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
            return View(banque);
        }

        // GET: Banques/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Banques == null)
            {
                return NotFound();
            }

            var banque = await _context.Banques
                .FirstOrDefaultAsync(m => m.Na == id);
            if (banque == null)
            {
                return NotFound();
            }

            return View(banque);
        }

        // POST: Banques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Banques == null)
            {
                return Problem("Entity set 'RecuDbContext.Banques'  is null.");
            }
            var banque = await _context.Banques.FindAsync(id);
            if (banque != null)
            {
                _context.Banques.Remove(banque);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BanqueExists(string id)
        {
          return _context.Banques.Any(e => e.Na == id);
        }
    }
}
