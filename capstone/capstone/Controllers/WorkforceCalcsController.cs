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
    public class WorkforceCalcsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkforceCalcsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WorkforceCalcs
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkforceCalc.ToListAsync());
        }

        // GET: WorkforceCalcs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workforceCalc = await _context.WorkforceCalc
                .FirstOrDefaultAsync(m => m.WorkforceCalcId == id);
            if (workforceCalc == null)
            {
                return NotFound();
            }

            return View(workforceCalc);
        }

        // GET: WorkforceCalcs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkforceCalcs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkforceCalcId,EmployeePayRateId,ManagmentHours,ManagmentCost,LaborHours,LaborCost")] WorkforceCalc workforceCalc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workforceCalc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workforceCalc);
        }

        // GET: WorkforceCalcs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workforceCalc = await _context.WorkforceCalc.FindAsync(id);
            if (workforceCalc == null)
            {
                return NotFound();
            }
            return View(workforceCalc);
        }

        // POST: WorkforceCalcs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkforceCalcId,EmployeePayRateId,ManagmentHours,ManagmentCost,LaborHours,LaborCost")] WorkforceCalc workforceCalc)
        {
            if (id != workforceCalc.WorkforceCalcId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workforceCalc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkforceCalcExists(workforceCalc.WorkforceCalcId))
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
            return View(workforceCalc);
        }

        // GET: WorkforceCalcs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workforceCalc = await _context.WorkforceCalc
                .FirstOrDefaultAsync(m => m.WorkforceCalcId == id);
            if (workforceCalc == null)
            {
                return NotFound();
            }

            return View(workforceCalc);
        }

        // POST: WorkforceCalcs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workforceCalc = await _context.WorkforceCalc.FindAsync(id);
            _context.WorkforceCalc.Remove(workforceCalc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkforceCalcExists(int id)
        {
            return _context.WorkforceCalc.Any(e => e.WorkforceCalcId == id);
        }
    }
}
