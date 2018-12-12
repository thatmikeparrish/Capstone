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
    public class TotalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TotalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Totals
        public async Task<IActionResult> Index()
        {
            return View(await _context.Total.ToListAsync());
        }

        // GET: Totals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var total = await _context.Total
                .FirstOrDefaultAsync(m => m.TotalId == id);
            if (total == null)
            {
                return NotFound();
            }

            return View(total);
        }

        // GET: Totals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Totals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TotalId,MaterialCost,MaterialMargin,MaterialQuote,SubCost,SubQuote,ManHours,UnburdenedRate,Burden,Insurance,LaborTotal,Travel,Consumables,InstallQuote,CompositeLabor,InstallQuoteTotal,SalesTax,Totals")] Total total)
        {
            if (ModelState.IsValid)
            {
                _context.Add(total);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(total);
        }

        // GET: Totals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var total = await _context.Total.FindAsync(id);
            if (total == null)
            {
                return NotFound();
            }
            return View(total);
        }

        // POST: Totals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TotalId,MaterialCost,MaterialMargin,MaterialQuote,SubCost,SubQuote,ManHours,UnburdenedRate,Burden,Insurance,LaborTotal,Travel,Consumables,InstallQuote,CompositeLabor,InstallQuoteTotal,SalesTax,Totals")] Total total)
        {
            if (id != total.TotalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(total);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TotalExists(total.TotalId))
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
            return View(total);
        }

        // GET: Totals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var total = await _context.Total
                .FirstOrDefaultAsync(m => m.TotalId == id);
            if (total == null)
            {
                return NotFound();
            }

            return View(total);
        }

        // POST: Totals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var total = await _context.Total.FindAsync(id);
            _context.Total.Remove(total);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TotalExists(int id)
        {
            return _context.Total.Any(e => e.TotalId == id);
        }
    }
}
