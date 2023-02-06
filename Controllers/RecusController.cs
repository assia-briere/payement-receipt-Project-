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
    public class RecusController : Controller
    {
        private readonly RecuDbContext _context;

        public RecusController(RecuDbContext context)
        {
            _context = context;
        }

        // GET: Recus
        public async Task<IActionResult> Index()
        {
            var recuDbContext = _context.Recus.Include(r => r.NcNavigation).Include(r => r.NdumNavigation).Include(r => r.NfNavigation);
            return View(await recuDbContext.ToListAsync());
        }

        // GET: Recus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Recus == null)
            {
                return NotFound();
            }

            var recu = await _context.Recus
                .Include(r => r.NcNavigation)
                .Include(r => r.NdumNavigation)
                .Include(r => r.NfNavigation)
                .FirstOrDefaultAsync(m => m.Nemuro == id);
            if (recu == null)
            {
                return NotFound();
            }

            return View(recu);
        }

        // GET: Recus/Create
        public IActionResult Create()
        {
            ViewData["Nc"] = new SelectList(_context.Cheques, "Ncheque", "Ncheque");
            ViewData["Ndum"] = new SelectList(_context.Demandes, "Ndum", "Ndum");
            ViewData["Nf"] = new SelectList(_context.Factures, "Nfacture", "Nfacture");
            return View();
        }

        // POST: Recus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nemuro,Date,ModePaiement,Ndum,Nf,Payeur,Nc")] Recu recu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Nc"] = new SelectList(_context.Cheques, "Ncheque", "Ncheque", recu.Nc);
            ViewData["Ndum"] = new SelectList(_context.Demandes, "Ndum", "Ndum", recu.Ndum);
            ViewData["Nf"] = new SelectList(_context.Factures, "Nfacture", "Nfacture", recu.Nf);
            return View(recu);
        }

        // GET: Recus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Recus == null)
            {
                return NotFound();
            }

            var recu = await _context.Recus.FindAsync(id);
            if (recu == null)
            {
                return NotFound();
            }
            ViewData["Nc"] = new SelectList(_context.Cheques, "Ncheque", "Ncheque", recu.Nc);
            ViewData["Ndum"] = new SelectList(_context.Demandes, "Ndum", "Ndum", recu.Ndum);
            ViewData["Nf"] = new SelectList(_context.Factures, "Nfacture", "Nfacture", recu.Nf);
            return View(recu);
        }

        // POST: Recus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nemuro,Date,ModePaiement,Ndum,Nf,Payeur,Nc")] Recu recu)
        {
            if (id != recu.Nemuro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecuExists(recu.Nemuro))
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
            ViewData["Nc"] = new SelectList(_context.Cheques, "Ncheque", "Ncheque", recu.Nc);
            ViewData["Ndum"] = new SelectList(_context.Demandes, "Ndum", "Ndum", recu.Ndum);
            ViewData["Nf"] = new SelectList(_context.Factures, "Nfacture", "Nfacture", recu.Nf);
            return View(recu);
        }

        // GET: Recus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Recus == null)
            {
                return NotFound();
            }

            var recu = await _context.Recus
                .Include(r => r.NcNavigation)
                .Include(r => r.NdumNavigation)
                .Include(r => r.NfNavigation)
                .FirstOrDefaultAsync(m => m.Nemuro == id);
            if (recu == null)
            {
                return NotFound();
            }

            return View(recu);
        }

        // POST: Recus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Recus == null)
            {
                return Problem("Entity set 'RecuDbContext.Recus'  is null.");
            }
            var recu = await _context.Recus.FindAsync(id);
            if (recu != null)
            {
                _context.Recus.Remove(recu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecuExists(int id)
        {
          return _context.Recus.Any(e => e.Nemuro == id);
        }
    }
}
