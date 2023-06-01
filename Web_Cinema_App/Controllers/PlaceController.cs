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
    public class PlaceController : Controller
    {
        private readonly DataContextPlace _context;

        public PlaceController(DataContextPlace context)
        {
            _context = context;
        }

        // GET: Place
        public async Task<IActionResult> Index()
        {
              return _context.Place != null ? 
                          View(await _context.Place.ToListAsync()) :
                          Problem("Entity set 'DataContextPlace.Place'  is null.");
        }        

        // GET: Place/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Place/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdRoom,Number,Row")] PlaceModel placeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(placeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(placeModel);
        }

        // GET: Place/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Place == null)
            {
                return NotFound();
            }

            var placeModel = await _context.Place.FindAsync(id);
            if (placeModel == null)
            {
                return NotFound();
            }
            return View(placeModel);
        }

        // POST: Place/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdRoom,Number,Row")] PlaceModel placeModel)
        {
            if (id != placeModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(placeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaceModelExists(placeModel.Id))
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
            return View(placeModel);
        }

        // GET: Place/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Place == null)
            {
                return NotFound();
            }

            var placeModel = await _context.Place
                .FirstOrDefaultAsync(m => m.Id == id);
            if (placeModel == null)
            {
                return NotFound();
            }

            return View(placeModel);
        }

        // POST: Place/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Place == null)
            {
                return Problem("Entity set 'DataContextPlace.Place'  is null.");
            }
            var placeModel = await _context.Place.FindAsync(id);
            if (placeModel != null)
            {
                _context.Place.Remove(placeModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlaceModelExists(int id)
        {
          return (_context.Place?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
