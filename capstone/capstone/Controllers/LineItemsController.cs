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
    public class LineItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LineItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LineItems
        [Authorize]
        public IActionResult Index()
        {
            var allLineItems = _context.LineItem.Include("Project").ToList().Select(li => new LineItem
            {
                LineItemId = li.LineItemId,
                ProjectId = li.ProjectId,
                Project = li.Project,
                Description = li.Description,
                MaterialCost = li.MaterialCost,
                SubCost = li.SubCost,
                ManHours = li.ManHours,
                LaborCost = li.ManHours * li.Project.UnburdenedRate,
                LaborQuote = (li.ManHours * li.Project.UnburdenedRate) * (1 + li.Project.LaborMargin),
                QuoteSalesTax = li.MaterialQuote * li.Project.ProjectSalesTax
            });

            return View(allLineItems);
        }

        // GET: LineItems/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lineItem = await _context.LineItem
                .FirstOrDefaultAsync(m => m.LineItemId == id);
            if (lineItem == null)
            {
                return NotFound();
            }

            return View(lineItem);
        }

        // GET: LineItems/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectNumber");
            return View();
        }

        // POST: LineItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("LineItemId,ProjectId,Description,MaterialCost,SubCost,ManHours")] LineItem lineItem)
        {
            if (ModelState.IsValid)
            {
                var ProjectId = lineItem.ProjectId;
                _context.Add(lineItem);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Projects", new { id = ProjectId });
            }
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectNumber");
            return View(lineItem);
        }

        // GET: LineItems/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lineItem = await _context.LineItem.FindAsync(id);
            if (lineItem == null)
            {
                return NotFound();
            }
            return View(lineItem);
        }

        // POST: LineItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("LineItemId,ProjectId,Description,MaterialCost,SubCost,ManHours")] LineItem lineItem)
        {
            var ProjectId = lineItem.ProjectId;
            if (id != lineItem.LineItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lineItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LineItemExists(lineItem.LineItemId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Projects", new { id = ProjectId });
            }
            return View(lineItem);
        }

        // GET: LineItems/Delete/5
        [Authorize]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lineItem = _context.LineItem.Include("Project").ToList().Select(li => new LineItem
            {
                LineItemId = li.LineItemId,
                ProjectId = li.ProjectId,
                Project = li.Project,
                Description = li.Description,
                MaterialCost = li.MaterialCost,
                SubCost = li.SubCost,
                ManHours = li.ManHours,
                LaborCost = li.ManHours * li.Project.UnburdenedRate,
                LaborQuote = (li.ManHours * li.Project.UnburdenedRate) * (1 + li.Project.LaborMargin),
                QuoteSalesTax = li.MaterialQuote * li.Project.ProjectSalesTax
            })
                .FirstOrDefault(m => m.LineItemId == id);

            if (lineItem == null)
            {
                return NotFound();
            }

            return View(lineItem);
        }

        // POST: LineItems/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lineItem = await _context.LineItem.FindAsync(id);
            var ProjectId = lineItem.ProjectId;
            _context.LineItem.Remove(lineItem);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Projects", new { id = ProjectId});
        }

        private bool LineItemExists(int id)
        {
            return _context.LineItem.Any(e => e.LineItemId == id);
        }
    }
}
