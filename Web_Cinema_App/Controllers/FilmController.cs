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
    public class FilmController : Controller
    {
        private readonly DataContextFilm _context;

        public FilmController(DataContextFilm context)
        {
            _context = context;
        }

        // GET: Film
        public async Task<IActionResult> Index()
        {
              return _context.FilmModel != null ? 
                          View(await _context.FilmModel.ToListAsync()) :
                          Problem("Entity set 'DataContextFilm.FilmModel'  is null.");
        }

        // GET: Film/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FilmModel == null)
            {
                return NotFound();
            }

            var filmModel = await _context.FilmModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filmModel == null)
            {
                return NotFound();
            }

            return View(filmModel);
        }

        // GET: Film/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Film/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,IdGenre")] FilmModel filmModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filmModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filmModel);
        }

        // GET: Film/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FilmModel == null)
            {
                return NotFound();
            }

            var filmModel = await _context.FilmModel.FindAsync(id);
            if (filmModel == null)
            {
                return NotFound();
            }
            return View(filmModel);
        }

        // POST: Film/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,IdGenre")] FilmModel filmModel)
        {
            if (id != filmModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmModelExists(filmModel.Id))
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
            return View(filmModel);
        }

        // GET: Film/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FilmModel == null)
            {
                return NotFound();
            }

            var filmModel = await _context.FilmModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filmModel == null)
            {
                return NotFound();
            }

            return View(filmModel);
        }

        // POST: Film/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FilmModel == null)
            {
                return Problem("Entity set 'DataContextFilm.FilmModel'  is null.");
            }
            var filmModel = await _context.FilmModel.FindAsync(id);
            if (filmModel != null)
            {
                _context.FilmModel.Remove(filmModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmModelExists(int id)
        {
          return (_context.FilmModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
