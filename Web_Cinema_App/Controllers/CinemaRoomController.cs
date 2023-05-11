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
    public class CinemaRoomController : Controller
    {
        private readonly DataContextCinemaRoom _context;

        public CinemaRoomController(DataContextCinemaRoom context)
        {
            _context = context;
        }

        // GET: CinemaRoom
        public async Task<IActionResult> Index()
        {
              return _context.CinemaRoom != null ? 
                          View(await _context.CinemaRoom.ToListAsync()) :
                          Problem("Entity set 'DataContextCinemaRoom.CinemaRoom'  is null.");
        }

        // GET: CinemaRoom/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CinemaRoom == null)
            {
                return NotFound();
            }

            var cinemaRoomModel = await _context.CinemaRoom
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cinemaRoomModel == null)
            {
                return NotFound();
            }

            return View(cinemaRoomModel);
        }

        // GET: CinemaRoom/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CinemaRoom/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name_Room,Id_Cinema")] CinemaRoomModel cinemaRoomModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cinemaRoomModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cinemaRoomModel);
        }

        // GET: CinemaRoom/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CinemaRoom == null)
            {
                return NotFound();
            }

            var cinemaRoomModel = await _context.CinemaRoom.FindAsync(id);
            if (cinemaRoomModel == null)
            {
                return NotFound();
            }
            return View(cinemaRoomModel);
        }

        // POST: CinemaRoom/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name_Room,Id_Cinema")] CinemaRoomModel cinemaRoomModel)
        {
            if (id != cinemaRoomModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cinemaRoomModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CinemaRoomModelExists(cinemaRoomModel.Id))
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
            return View(cinemaRoomModel);
        }

        // GET: CinemaRoom/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CinemaRoom == null)
            {
                return NotFound();
            }

            var cinemaRoomModel = await _context.CinemaRoom
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cinemaRoomModel == null)
            {
                return NotFound();
            }

            return View(cinemaRoomModel);
        }

        // POST: CinemaRoom/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CinemaRoom == null)
            {
                return Problem("Entity set 'DataContextCinemaRoom.CinemaRoom'  is null.");
            }
            var cinemaRoomModel = await _context.CinemaRoom.FindAsync(id);
            if (cinemaRoomModel != null)
            {
                _context.CinemaRoom.Remove(cinemaRoomModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CinemaRoomModelExists(int id)
        {
          return (_context.CinemaRoom?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
