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
    public class SessionController : Controller
    {
        private readonly DataContextSession _context;

        public SessionController(DataContextSession context)
        {
            _context = context;
        }

        // GET: Session
        public async Task<IActionResult> Index()
        {
              return _context.Sessions != null ? 
                          View(await _context.Sessions.ToListAsync()) :
                          Problem("Entity set 'DataContextSession.Sessions'  is null.");
        }

        // GET: Session/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Session/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Time,IdFilm")] SessionModel sessionModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sessionModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sessionModel);
        }

        // GET: Session/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sessions == null)
            {
                return NotFound();
            }

            var sessionModel = await _context.Sessions.FindAsync(id);
            if (sessionModel == null)
            {
                return NotFound();
            }
            return View(sessionModel);
        }

        // POST: Session/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Time,IdFilm")] SessionModel sessionModel)
        {
            if (id != sessionModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sessionModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SessionModelExists(sessionModel.Id))
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
            return View(sessionModel);
        }

        // GET: Session/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sessions == null)
            {
                return NotFound();
            }

            var sessionModel = await _context.Sessions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sessionModel == null)
            {
                return NotFound();
            }

            return View(sessionModel);
        }

        // POST: Session/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sessions == null)
            {
                return Problem("Entity set 'DataContextSession.Sessions'  is null.");
            }
            var sessionModel = await _context.Sessions.FindAsync(id);
            if (sessionModel != null)
            {
                _context.Sessions.Remove(sessionModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SessionModelExists(int id)
        {
          return (_context.Sessions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
