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
    public class ChequesController : Controller
    {
        private readonly RecuDbContext _context;

        public ChequesController(RecuDbContext context)
        {
            _context = context;
        }

        // GET: Cheques
        public async Task<IActionResult> Index()
        {
            var recuDbContext = _context.Cheques.Include(c => c.BanqueNavigation);
            return View(await recuDbContext.ToListAsync());
        }

        // GET: Cheques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cheques == null)
            {
                return NotFound();
            }

            var cheque = await _context.Cheques
                .Include(c => c.BanqueNavigation)
                .FirstOrDefaultAsync(m => m.Ncheque == id);
            if (cheque == null)
            {
                return NotFound();
            }

            return View(cheque);
        }

        // GET: Cheques/Create
        public IActionResult Create()
        {
            ViewData["Banque"] = new SelectList(_context.Banques, "Na", "Na");
            return View();
        }

        // POST: Cheques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ncheque,MontantLettre,MontantChiffres,Date,Lieu,Beneficiare,Banque")] Cheque cheque)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cheque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Banque"] = new SelectList(_context.Banques, "Na", "Na", cheque.Banque);
            return View(cheque);
        }

        // GET: Cheques/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cheques == null)
            {
                return NotFound();
            }

            var cheque = await _context.Cheques.FindAsync(id);
            if (cheque == null)
            {
                return NotFound();
            }
            ViewData["Banque"] = new SelectList(_context.Banques, "Na", "Na", cheque.Banque);
            return View(cheque);
        }

        // POST: Cheques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Ncheque,MontantLettre,MontantChiffres,Date,Lieu,Beneficiare,Banque")] Cheque cheque)
        {
            if (id != cheque.Ncheque)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cheque);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChequeExists(cheque.Ncheque))
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
            ViewData["Banque"] = new SelectList(_context.Banques, "Na", "Na", cheque.Banque);
            return View(cheque);
        }

        // GET: Cheques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cheques == null)
            {
                return NotFound();
            }

            var cheque = await _context.Cheques
                .Include(c => c.BanqueNavigation)
                .FirstOrDefaultAsync(m => m.Ncheque == id);
            if (cheque == null)
            {
                return NotFound();
            }

            return View(cheque);
        }

        // POST: Cheques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cheques == null)
            {
                return Problem("Entity set 'RecuDbContext.Cheques'  is null.");
            }
            var cheque = await _context.Cheques.FindAsync(id);
            if (cheque != null)
            {
                _context.Cheques.Remove(cheque);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChequeExists(int id)
        {
          return _context.Cheques.Any(e => e.Ncheque == id);
        }
    }
}
