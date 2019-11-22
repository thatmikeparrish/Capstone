using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using capstone.Data;
using capstone.Models;
using Microsoft.AspNetCore.Authorization;

namespace capstone.Controllers
{
    public class TimeTrackersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TimeTrackersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TimeTrackers
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TimeTracker.Include(t => t.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TimeTrackers/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeTracker = await _context.TimeTracker
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.TimeTrackerId == id);
            if (timeTracker == null)
            {
                return NotFound();
            }

            return View(timeTracker);
        }

        // GET: TimeTrackers/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View();
        }

        // POST: TimeTrackers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("TimeTrackerId,UserId,Date,Hours,Comments")] TimeTracker timeTracker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timeTracker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", timeTracker.UserId);
            return View(timeTracker);
        }

        // GET: TimeTrackers/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeTracker = await _context.TimeTracker.FindAsync(id);
            if (timeTracker == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", timeTracker.UserId);
            return View(timeTracker);
        }

        // POST: TimeTrackers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("TimeTrackerId,UserId,Date,Hours,Comments")] TimeTracker timeTracker)
        {
            if (id != timeTracker.TimeTrackerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeTracker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeTrackerExists(timeTracker.TimeTrackerId))
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
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", timeTracker.UserId);
            return View(timeTracker);
        }

        // GET: TimeTrackers/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeTracker = await _context.TimeTracker
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.TimeTrackerId == id);
            if (timeTracker == null)
            {
                return NotFound();
            }

            return View(timeTracker);
        }

        // POST: TimeTrackers/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timeTracker = await _context.TimeTracker.FindAsync(id);
            _context.TimeTracker.Remove(timeTracker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeTrackerExists(int id)
        {
            return _context.TimeTracker.Any(e => e.TimeTrackerId == id);
        }
    }
}
