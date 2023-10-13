using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcTire.Data;
using MvcTire.Models;

namespace MvcTire.Controllers
{
    public class TiresController : Controller
    {
        private readonly MvcTireContext _context;

        public TiresController(MvcTireContext context)
        {
            _context = context;
        }

        // GET: Tires
        //public async Task<IActionResult> Index(string searchString)
        //{
        //    var tires = from t in _context.Tire
        //                 select t;

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        tires = tires.Where(s => s.Brand.Contains(searchString));
        //    }

        //    return View(await tires.ToListAsync());
        //}
        // updated the code

        // GET: Movies
        public async Task<IActionResult> Index(string tireColor, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> colorQuery = from t in _context.Tire
                                            orderby t.Color
                                            select t.Color;

            var tires = from t in _context.Tire
                         select t;

            if (!string.IsNullOrEmpty(searchString))
            {
                tires = tires.Where(s => s.Brand.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(tireColor))
            {
                tires = tires.Where(x => x.Color == tireColor);
            }

            var tireColorVM = new TireColorViewModel
            {
                Colors = new SelectList(await colorQuery.Distinct().ToListAsync()),
                Tires = await tires.ToListAsync()
            };

            return View(tireColorVM);
        }
        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        // GET: Tires/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tire = await _context.Tire
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tire == null)
            {
                return NotFound();
            }

            return View(tire);
        }

        // GET: Tires/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tires/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Brand,Color,Price,Size")] Tire tire)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tire);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tire);
        }

        // GET: Tires/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tire = await _context.Tire.FindAsync(id);
            if (tire == null)
            {
                return NotFound();
            }
            return View(tire);
        }

        // POST: Tires/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brand,Color,Price,Size,Rating")] Tire tire)
        {
            if (id != tire.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tire);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TireExists(tire.Id))
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
            return View(tire);
        }

        // GET: Tires/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tire = await _context.Tire
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tire == null)
            {
                return NotFound();
            }

            return View(tire);
        }

        // POST: Tires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tire = await _context.Tire.FindAsync(id);
            _context.Tire.Remove(tire);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TireExists(int id)
        {
            return _context.Tire.Any(e => e.Id == id);
        }
    }
}
