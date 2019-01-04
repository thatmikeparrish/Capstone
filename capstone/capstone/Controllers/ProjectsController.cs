using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using capstone.Data;
using capstone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace capstone.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProjectsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Projects
        [Authorize]
        public IActionResult Index()
        {
            // Showing two different kinds of ways to do ".Include()"
            var allProjects = _context.Project
                .Include("Client")
                .Include(p => p.LineItems)
                .ToList()
                .Select(p => new Project
                {
                    ProjectId = p.ProjectId,
                    UserId = p.UserId,
                    ClientId = p.ClientId,
                    Client = p.Client,
                    ProjectNumber = p.ProjectNumber,
                    WorkDay = p.WorkDay,
                    SalesTax = p.SalesTax,
                    UnburdenedRate = p.UnburdenedRate,
                    LaborMargin = p.LaborMargin,
                    CompletionDate = p.CompletionDate,
                    IsCompleted = p.IsCompleted,
                    TimeTrackerId = p.TimeTrackerId,
                    TotalMaterialCost = p.LineItems.Sum(m => m.MaterialCost),
                    TotalMaterialQuote = p.LineItems.Sum(m => m.MaterialQuote),
                    TotalSubCost = p.LineItems.Sum(m => m.SubCost),
                    TotalSubQuote = p.LineItems.Sum(m => m.SubQuote),
                    TotalManHours = p.LineItems.Sum(m => m.ManHours),
                });

            return View(allProjects);
        }

        // GET: Projects/Details/5
        [Authorize]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allProjects = _context.Project
                .Include("Client")
                .Include(p => p.LineItems)
                .Include(p => p.CrewMembers)
                .Where(m => m.ProjectId == id).
                Select(p => new Project
                {
                    ProjectId = p.ProjectId,
                    UserId = p.UserId,
                    ClientId = p.ClientId,
                    Client = p.Client,
                    LineItems = p.LineItems,
                    CrewMembers = p.CrewMembers,
                    ProjectNumber = p.ProjectNumber,
                    SubmittedDate = p.SubmittedDate,
                    ExpirationDate = p.ExpirationDate,
                    WorkDay = p.WorkDay,
                    SalesTax = p.SalesTax,
                    UnburdenedRate = p.UnburdenedRate,
                    CrewSize = p.CrewMembers.Sum(m => m.EmployeeQuantity),
                    LaborMargin = p.LaborMargin,
                    CompletionDate = p.CompletionDate,
                    IsCompleted = p.IsCompleted,
                    TimeTrackerId = p.TimeTrackerId,
                    TotalMaterialCost = p.LineItems.Sum(m => m.MaterialCost),
                    TotalMaterialQuote = p.LineItems.Sum(m => m.MaterialQuote),
                    TotalSubCost = p.LineItems.Sum(m => m.SubCost),
                    TotalSubQuote = p.LineItems.Sum(m => m.SubQuote),
                    TotalManHours = p.LineItems.Sum(m => m.ManHours),
                })
                .FirstOrDefault();

                allProjects.LineItems = allProjects.LineItems
                .Select(li => new LineItem
                {
                    LineItemId = li.LineItemId,
                    ProjectId = li.ProjectId,
                    Project = li.Project,
                    Description = li.Description,
                    MaterialCost = li.MaterialCost,
                    SubCost = li.SubCost,
                    ManHours = li.ManHours,
                    LaborCost = li.ManHours * allProjects.UnburdenedRate,
                    LaborQuote = (li.ManHours * allProjects.UnburdenedRate) * (1 + allProjects.LaborMargin),
                    QuoteSalesTax = li.MaterialQuote * allProjects.ProjectSalesTax
                }).ToList();

                allProjects.CrewMembers = allProjects.CrewMembers
                .Select(c => new Crew
                {
                    CrewId = c.CrewId,
                    ProjectId = c.ProjectId,
                    EmployeeTypeId = c.EmployeeTypeId,
                    EmployeeType = c.EmployeeType,
                    PayRate = c.PayRate,
                    EmployeeQuantity = c.EmployeeQuantity,
                    LaborHours = c.EmployeeQuantity * allProjects.WorkDay * allProjects.WorkingDays,
                }).ToList();

            if (allProjects == null)
            {
                return NotFound();
            }

            return View(allProjects);
        }

        // GET: Projects/Create
        [Authorize]
        public IActionResult Create()
        {
           ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "FullName");
           ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("ProjectId,UserId,ClientId,ProjectNumber,LineItemId,SubmittedDate,ExpirationDate,CompletionDate,IsCompleted,TimeTrackerId")] Project project)
        {
            var user = await GetCurrentUserAsync();

            if (user != null)
            {
                project.UserId = user.Id;
                project.IsCompleted = false;
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "FullName", project.ClientId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", project.UserId);
            return View(project);
        }

        // GET: Projects/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "FullName", project.ClientId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", project.UserId);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectId,UserId,ClientId,ProjectNumber,SubmittedDate,ExpirationDate,IsCompleted,CompletionDate")] Project project)
        {
            var ProjectId = project.ProjectId;
            if (id != project.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var editProject = await _context.Project.FindAsync(id);
                    editProject.ProjectNumber = project.ProjectNumber;
                    editProject.ClientId = project.ClientId;
                    editProject.SubmittedDate = project.SubmittedDate;
                    editProject.ExpirationDate = project.ExpirationDate;
                    editProject.IsCompleted = project.IsCompleted;
                    editProject.CompletionDate = project.CompletionDate;
                    _context.Update(editProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.ProjectId))
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
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "FullName", project.ClientId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", project.UserId);
            return View(project);
        }

        // GET: Projects/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .Include(p => p.Client)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Project.FindAsync(id);
            _context.Project.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return _context.Project.Any(e => e.ProjectId == id);
        }

        // GET: Projects/Quote/5
        [Authorize]
        public IActionResult Quote(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allProjects = _context.Project
                .Include("Client")
                .Include(p => p.LineItems)
                .Where(m => m.ProjectId == id).
                Select(p => new Project
                {
                    ProjectId = p.ProjectId,
                    UserId = p.UserId,
                    ClientId = p.ClientId,
                    Client = p.Client,
                    LineItems = p.LineItems,
                    ProjectNumber = p.ProjectNumber,
                    SubmittedDate = p.SubmittedDate,
                    ExpirationDate = p.ExpirationDate,
                    WorkDay = p.WorkDay,
                    SalesTax = p.SalesTax,
                    UnburdenedRate = p.UnburdenedRate,
                    LaborMargin = p.LaborMargin,
                    CompletionDate = p.CompletionDate,
                    IsCompleted = p.IsCompleted,
                    TimeTrackerId = p.TimeTrackerId,
                    TotalMaterialCost = p.LineItems.Sum(m => m.MaterialCost),
                    TotalMaterialQuote = p.LineItems.Sum(m => m.MaterialQuote),
                    TotalSubCost = p.LineItems.Sum(m => m.SubCost),
                    TotalSubQuote = p.LineItems.Sum(m => m.SubQuote),
                    TotalManHours = p.LineItems.Sum(m => m.ManHours),
                })
                .FirstOrDefault();

            allProjects.LineItems = allProjects.LineItems
            .Select(li => new LineItem
            {
                LineItemId = li.LineItemId,
                ProjectId = li.ProjectId,
                Project = li.Project,
                Description = li.Description,
                MaterialCost = li.MaterialCost,
                SubCost = li.SubCost,
                ManHours = li.ManHours,
                LaborCost = li.ManHours * allProjects.UnburdenedRate,
                LaborQuote = (li.ManHours * allProjects.UnburdenedRate) * (1 + allProjects.LaborMargin),
                QuoteSalesTax = li.MaterialQuote * allProjects.ProjectSalesTax
            }).ToList();

            if (allProjects == null)
            {
                return NotFound();
            }

            return View(allProjects);
        }
    }
}
