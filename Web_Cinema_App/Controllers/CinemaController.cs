using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_Cinema_App.Entities;
using Web_Cinema_App.Models;

namespace Web_Cinema_App.Controllers
{
    public class CinemaController : Controller
    {
        public readonly DataContextCinema _context;

        public CinemaController(DataContextCinema context)
        {
            _context = context;
        }

        public List<string> GetCinemaName()
        {
            List<string> cinemaName = new List<string>();
            foreach (var item in _context.Cinema.ToList())
                cinemaName.Add(item.NameCinema);
            return cinemaName;
        }

        // GET: Cinema
        public async Task<IActionResult> Index()
        {
              return _context.Cinema != null ? 
                          View(await _context.Cinema.ToListAsync()) :
                          Problem("Entity set 'DataContext.Cinema'  is null.");
        }

        // GET: Cinema/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cinema == null)
            {
                return NotFound();
            }

            var cinemaModel = await _context.Cinema
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cinemaModel == null)
            {
                return NotFound();
            }

            return View(cinemaModel);
        }

        // GET: Cinema/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cinema/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name_cinema")] CinemaModel cinemaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cinemaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cinemaModel);
        }

        // GET: Cinema/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cinema == null)
            {
                return NotFound();
            }

            var cinemaModel = await _context.Cinema.FindAsync(id);
            if (cinemaModel == null)
            {
                return NotFound();
            }
            return View(cinemaModel);
        }

        // POST: Cinema/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name_cinema")] CinemaModel cinemaModel)
        {
            if (id != cinemaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cinemaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CinemaModelExists(cinemaModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(cinemaModel);
        }

        // GET: Cinema/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cinema == null)
            {
                return NotFound();
            }

            var cinemaModel = await _context.Cinema
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cinemaModel == null)
            {
                return NotFound();
            }

            return View(cinemaModel);
        }

        // POST: Cinema/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cinema == null)
            {
                return Problem("Entity set 'DataContext.Cinema'  is null.");
            }
            var cinemaModel = await _context.Cinema.FindAsync(id);
            if (cinemaModel != null)
            {
                _context.Cinema.Remove(cinemaModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CinemaModelExists(int id)
        {
          return (_context.Cinema?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
