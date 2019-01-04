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
    public class CrewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CrewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Crews
        [Authorize]
        public IActionResult Index()
        {
            var allCrews = _context.Crew.Include("EmployeeType").ToList().Select(c => new Crew
            {
                CrewId = c.CrewId,
                ProjectId = c.ProjectId,
                EmployeeTypeId = c.EmployeeTypeId,
                PayRate = c.PayRate,
                EmployeeQuantity = c.EmployeeQuantity
            });
            return View(allCrews);
        }

        // GET: Crews/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crew = await _context.Crew
                .FirstOrDefaultAsync(m => m.CrewId == id);
            if (crew == null)
            {
                return NotFound();
            }

            return View(crew);
        }

        // GET: Crews/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectNumber");
            ViewData["EmployeeTypeId"] = new SelectList(_context.EmployeeType, "EmployeeTypeId", "Category");
            return View();
        }

        // POST: Crews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("CrewId,ProjectId,EmployeeTypeId,PayRate,EmployeeQuantity")] Crew crew)
        {
            if (ModelState.IsValid)
            {
                var ProjectId = crew.ProjectId;
                _context.Add(crew);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Projects", new { id = ProjectId });
            }
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectNumber");
            ViewData["EmployeeTypeId"] = new SelectList(_context.EmployeeType, "EmployeeTypeId", "Category");
            return View(crew);
        }

        // GET: Crews/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crew = await _context.Crew.FindAsync(id);
            if (crew == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectNumber");
            ViewData["EmployeeTypeId"] = new SelectList(_context.EmployeeType, "EmployeeTypeId", "Category");
            return View(crew);
        }

        // POST: Crews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("CrewId,ProjectId,EmployeeTypeId,PayRate,EmployeeQuantity")] Crew crew)
        {
            var ProjectId = crew.ProjectId;
            if (id != crew.CrewId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var editCrew = await _context.Crew.FindAsync(id);
                    editCrew.ProjectId = crew.ProjectId;
                    editCrew.EmployeeTypeId = crew.EmployeeTypeId;
                    editCrew.PayRate = crew.PayRate;
                    editCrew.EmployeeQuantity = crew.EmployeeQuantity;
                    _context.Update(editCrew);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CrewExists(crew.CrewId))
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
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectNumber");
            ViewData["EmployeeTypeId"] = new SelectList(_context.EmployeeType, "EmployeeTypeId", "Category");
            return View(crew);
        }

        // GET: Crews/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crew = await _context.Crew
                .FirstOrDefaultAsync(m => m.CrewId == id);
            if (crew == null)
            {
                return NotFound();
            }

            return View(crew);
        }

        // POST: Crews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var crew = await _context.Crew.FindAsync(id);
            var ProjectId = crew.ProjectId;
            _context.Crew.Remove(crew);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Projects", new { id = ProjectId });
        }

        private bool CrewExists(int id)
        {
            return _context.Crew.Any(e => e.CrewId == id);
        }
    }
}
