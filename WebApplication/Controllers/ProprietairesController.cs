using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Agricathon2022;
using EFCoreApp2021;

namespace WebApplication.Controllers
{
    public class ProprietairesController : Controller
    {
        private readonly AgricathonContext _context;

        public ProprietairesController(AgricathonContext context)
        {
            _context = context;
        }

        // GET: Proprietaires
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProprietaireSet.ToListAsync());
        }

        // GET: Proprietaires/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proprietaire = await _context.ProprietaireSet
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (proprietaire == null)
            {
                return NotFound();
            }

            return View(proprietaire);
        }

        // GET: Proprietaires/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proprietaires/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,Firstname,Lastname,NoExploitant,EstExploitant,EstPropriétaire,DateNaissance,Address,Email,Password")] Proprietaire proprietaire)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proprietaire);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proprietaire);
        }

        // GET: Proprietaires/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proprietaire = await _context.ProprietaireSet.FindAsync(id);
            if (proprietaire == null)
            {
                return NotFound();
            }
            return View(proprietaire);
        }

        // POST: Proprietaires/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserID,Firstname,Lastname,NoExploitant,EstExploitant,EstPropriétaire,DateNaissance,Address,Email,Password")] Proprietaire proprietaire)
        {
            if (id != proprietaire.UserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proprietaire);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProprietaireExists(proprietaire.UserID))
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
            return View(proprietaire);
        }

        // GET: Proprietaires/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proprietaire = await _context.ProprietaireSet
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (proprietaire == null)
            {
                return NotFound();
            }

            return View(proprietaire);
        }

        // POST: Proprietaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proprietaire = await _context.ProprietaireSet.FindAsync(id);
            _context.ProprietaireSet.Remove(proprietaire);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProprietaireExists(int id)
        {
            return _context.ProprietaireSet.Any(e => e.UserID == id);
        }
    }
}
