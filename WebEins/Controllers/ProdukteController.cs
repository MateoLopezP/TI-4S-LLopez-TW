using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebEins.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebEins.Controllers
{
    public class ProdukteController : Controller
    {
        private readonly WEContext _context;

        public ProdukteController(WEContext context)
        {
            _context = context;
        }

        // GET: Produkte
        public async Task<IActionResult> Index(string? Suchen = "")
        {
            if (string.IsNullOrEmpty(Suchen))
            {
                var data = await _context.Produkte.ToListAsync();

                ViewData["qty"] = GetMenge(data);
                ViewBag.GetMenge = GetMenge(data);
                ViewBag.Gesamtbewertung = Gesamtbewertung(data);
                return View(data);
            }
            else
            {
                var Ergebnis = _context.Produkte
                    .Where(x => x.Beschreibung.ToLower().Contains(Suchen.ToLower()))
                    .ToList();
                ViewData["qty"] = GetMenge(Ergebnis);
                ViewBag.GetMenge = GetMenge(Ergebnis);
                ViewBag.Gesamtbewertung = Gesamtbewertung(Ergebnis);
                return View(Ergebnis);
            }
        }

        public async Task<IActionResult> MengeVerfügbar()
        {
            var Ergebnis = _context.Produkte
                .Where(x => x.Betrag <= 10)
                .ToList();
            ViewData["qty"] = GetMenge(Ergebnis);
            ViewBag.GetMenge = GetMenge(Ergebnis);
            ViewBag.Gesamnbewertung = Gesamtbewertung(Ergebnis);
            return View("index", Ergebnis);
        }

        private int GetMenge( IEnumerable<Produkte> produkte)
        {
            var menge = produkte.Count();
            return menge;
        }

        private double Gesamtbewertung(IEnumerable<Produkte> produkte)
        {
            var gesamtbewertung = produkte.Sum(x => x.Betrag * (double)x.Preis);
            return gesamtbewertung;
        }

        // GET: Produkte/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produkte = await _context.Produkte
                .FirstOrDefaultAsync(m => m.ID == id);
            if (produkte == null)
            {
                return NotFound();
            }

            return View(produkte);
        }

        // GET: Produkte/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produkte/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Beschreibung,Preis,Betrag")] Produkte produkte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produkte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produkte);
        }

        // GET: Produkte/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produkte = await _context.Produkte.FindAsync(id);
            if (produkte == null)
            {
                return NotFound();
            }
            return View(produkte);
        }

        // POST: Produkte/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Beschreibung,Preis,Betrag")] Produkte produkte)
        {
            if (id != produkte.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produkte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdukteExists(produkte.ID))
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
            return View(produkte);
        }

        // GET: Produkte/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produkte = await _context.Produkte
                .FirstOrDefaultAsync(m => m.ID == id);
            if (produkte == null)
            {
                return NotFound();
            }

            return View(produkte);
        }

        // POST: Produkte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produkte = await _context.Produkte.FindAsync(id);
            if (produkte != null)
            {
                _context.Produkte.Remove(produkte);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdukteExists(int id)
        {
            return _context.Produkte.Any(e => e.ID == id);
        }
    }
}
