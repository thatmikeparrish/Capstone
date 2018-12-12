using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using capstone.Data;
using capstone.Models;

namespace capstone.Controllers
{
    public class MarginsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MarginsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Margins
        public async Task<IActionResult> Index()
        {
            return View(await _context.Margin.ToListAsync());
        }

        // GET: Margins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var margin = await _context.Margin
                .FirstOrDefaultAsync(m => m.MarginId == id);
            if (margin == null)
            {
                return NotFound();
            }

            return View(margin);
        }

        // GET: Margins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Margins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MarginId,UnburdenedRate,Insurance,LaborTotal,Travel,Consumables,Equipment,CompositeLabor")] Margin margin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(margin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(margin);
        }

        // GET: Margins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var margin = await _context.Margin.FindAsync(id);
            if (margin == null)
            {
                return NotFound();
            }
            return View(margin);
        }

        // POST: Margins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MarginId,UnburdenedRate,Insurance,LaborTotal,Travel,Consumables,Equipment,CompositeLabor")] Margin margin)
        {
            if (id != margin.MarginId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(margin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarginExists(margin.MarginId))
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
            return View(margin);
        }

        // GET: Margins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var margin = await _context.Margin
                .FirstOrDefaultAsync(m => m.MarginId == id);
            if (margin == null)
            {
                return NotFound();
            }

            return View(margin);
        }

        // POST: Margins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var margin = await _context.Margin.FindAsync(id);
            _context.Margin.Remove(margin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarginExists(int id)
        {
            return _context.Margin.Any(e => e.MarginId == id);
        }
    }
}
