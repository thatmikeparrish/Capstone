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
    public class EmployeeTypePayRatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeTypePayRatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeTypePayRates
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EmployeeTypePayRate.Include(e => e.EmployeeType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EmployeeTypePayRates/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeTypePayRate = await _context.EmployeeTypePayRate
                .Include(e => e.EmployeeType)
                .FirstOrDefaultAsync(m => m.EmployeeTypePayRateId == id);
            if (employeeTypePayRate == null)
            {
                return NotFound();
            }

            return View(employeeTypePayRate);
        }

        // GET: EmployeeTypePayRates/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["EmployeeTypeId"] = new SelectList(_context.EmployeeType, "EmployeeTypeId", "Category");
            return View();
        }

        // POST: EmployeeTypePayRates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("EmployeeTypePayRateId,EmployeeTypeId,UnburdenedPayRate,EmployeeQuantity")] EmployeeTypePayRate employeeTypePayRate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeTypePayRate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeTypeId"] = new SelectList(_context.EmployeeType, "EmployeeTypeId", "Category", employeeTypePayRate.EmployeeTypeId);
            return View(employeeTypePayRate);
        }

        // GET: EmployeeTypePayRates/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeTypePayRate = await _context.EmployeeTypePayRate.FindAsync(id);
            if (employeeTypePayRate == null)
            {
                return NotFound();
            }
            ViewData["EmployeeTypeId"] = new SelectList(_context.EmployeeType, "EmployeeTypeId", "Category", employeeTypePayRate.EmployeeTypeId);
            return View(employeeTypePayRate);
        }

        // POST: EmployeeTypePayRates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeTypePayRateId,EmployeeTypeId,UnburdenedPayRate,EmployeeQuantity")] EmployeeTypePayRate employeeTypePayRate)
        {
            if (id != employeeTypePayRate.EmployeeTypePayRateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeTypePayRate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeTypePayRateExists(employeeTypePayRate.EmployeeTypePayRateId))
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
            ViewData["EmployeeTypeId"] = new SelectList(_context.EmployeeType, "EmployeeTypeId", "Category", employeeTypePayRate.EmployeeTypeId);
            return View(employeeTypePayRate);
        }

        // GET: EmployeeTypePayRates/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeTypePayRate = await _context.EmployeeTypePayRate
                .Include(e => e.EmployeeType)
                .FirstOrDefaultAsync(m => m.EmployeeTypePayRateId == id);
            if (employeeTypePayRate == null)
            {
                return NotFound();
            }

            return View(employeeTypePayRate);
        }

        // POST: EmployeeTypePayRates/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeTypePayRate = await _context.EmployeeTypePayRate.FindAsync(id);
            _context.EmployeeTypePayRate.Remove(employeeTypePayRate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeTypePayRateExists(int id)
        {
            return _context.EmployeeTypePayRate.Any(e => e.EmployeeTypePayRateId == id);
        }
    }
}
