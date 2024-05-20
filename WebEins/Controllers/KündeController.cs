using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebEins.Models;

namespace WebEins.Controllers
{
    public class KündeController : Controller
    {
        private readonly WEContext _context;

        public KündeController(WEContext context)
        {
            _context = context;
        }

        // GET: Künde
        public async Task<IActionResult> Index()
        {
            return View(await _context.Künde.ToListAsync());
        }

        // GET: Künde/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var künde = await _context.Künde
                .FirstOrDefaultAsync(m => m.Id == id);
            if (künde == null)
            {
                return NotFound();
            }

            return View(künde);
        }

        // GET: Künde/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Künde/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Beschreibung,Addresse,Personalnummer,Ausweisidentificactionsnummer")] Künde künde)
        {
            if (ModelState.IsValid)
            {
                _context.Add(künde);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(künde);
        }

        // GET: Künde/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var künde = await _context.Künde.FindAsync(id);
            if (künde == null)
            {
                return NotFound();
            }
            return View(künde);
        }

        // POST: Künde/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Beschreibung,Addresse,Personalnummer,Ausweisidentificactionsnummer")] Künde künde)
        {
            if (id != künde.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(künde);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KündeExists(künde.Id))
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
            return View(künde);
        }

        // GET: Künde/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var künde = await _context.Künde
                .FirstOrDefaultAsync(m => m.Id == id);
            if (künde == null)
            {
                return NotFound();
            }

            return View(künde);
        }

        // POST: Künde/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var künde = await _context.Künde.FindAsync(id);
            if (künde != null)
            {
                _context.Künde.Remove(künde);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KündeExists(int id)
        {
            return _context.Künde.Any(e => e.Id == id);
        }
    }
}
