using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFCoreApp2021;

namespace WebApplication.Controllers
{
    public class ParcellesController : Controller
    {
        private readonly AgricathonContext _context;

        public ParcellesController(AgricathonContext context)
        {
            _context = context;
        }

        // GET: Parcelles
        public async Task<IActionResult> Index()
        {
            var agricathonContext = _context.ParcelleSet.Include(p => p.Exploitant).Include(p => p.Propietaire);
            return View(await agricathonContext.ToListAsync());
        }

        // GET: Parcelles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parcelle = await _context.ParcelleSet
                .Include(p => p.Exploitant)
                .Include(p => p.Propietaire)
                .FirstOrDefaultAsync(m => m.EGRID == id);
            if (parcelle == null)
            {
                return NotFound();
            }

            return View(parcelle);
        }

        // GET: Parcelles/Create
        public IActionResult Create()
        {
            ViewData["ExploitantID"] = new SelectList(_context.ExploitantSet, "UserID", "Address");
            ViewData["ProprietaireID"] = new SelectList(_context.ProprietaireSet, "UserID", "Address");
            return View();
        }

        // POST: Parcelles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NoParcelle,EGRID,Cepage,Address,Surface,ExploitantID,ProprietaireID,Vente,Location,Prix,InfosSupp,Age")] Parcelle parcelle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parcelle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExploitantID"] = new SelectList(_context.ExploitantSet, "UserID", "Address", parcelle.ExploitantID);
            ViewData["ProprietaireID"] = new SelectList(_context.ProprietaireSet, "UserID", "Address", parcelle.ProprietaireID);
            return View(parcelle);
        }

        // GET: Parcelles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parcelle = await _context.ParcelleSet.FindAsync(id);
            if (parcelle == null)
            {
                return NotFound();
            }
            ViewData["ExploitantID"] = new SelectList(_context.ExploitantSet, "UserID", "Address", parcelle.ExploitantID);
            ViewData["ProprietaireID"] = new SelectList(_context.ProprietaireSet, "UserID", "Address", parcelle.ProprietaireID);
            return View(parcelle);
        }

        // POST: Parcelles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NoParcelle,EGRID,Cepage,Address,Surface,ExploitantID,ProprietaireID,Vente,Location,Prix,InfosSupp,Age")] Parcelle parcelle)
        {
            if (id != parcelle.EGRID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parcelle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParcelleExists(parcelle.EGRID))
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
            ViewData["ExploitantID"] = new SelectList(_context.ExploitantSet, "UserID", "Address", parcelle.ExploitantID);
            ViewData["ProprietaireID"] = new SelectList(_context.ProprietaireSet, "UserID", "Address", parcelle.ProprietaireID);
            return View(parcelle);
        }

        // GET: Parcelles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parcelle = await _context.ParcelleSet
                .Include(p => p.Exploitant)
                .Include(p => p.Propietaire)
                .FirstOrDefaultAsync(m => m.EGRID == id);
            if (parcelle == null)
            {
                return NotFound();
            }

            return View(parcelle);
        }

        // POST: Parcelles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var parcelle = await _context.ParcelleSet.FindAsync(id);
            _context.ParcelleSet.Remove(parcelle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParcelleExists(string id)
        {
            return _context.ParcelleSet.Any(e => e.EGRID == id);
        }
    }
}
