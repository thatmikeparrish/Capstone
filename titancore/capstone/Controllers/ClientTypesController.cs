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
    public class ClientTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClientTypes
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClientType.ToListAsync());
        }

        // GET: ClientTypes/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientType = await _context.ClientType
                .FirstOrDefaultAsync(m => m.ClientTypeId == id);
            if (clientType == null)
            {
                return NotFound();
            }

            return View(clientType);
        }

        // GET: ClientTypes/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClientTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("ClientTypeId,Category")] ClientType clientType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientType);
        }

        // GET: ClientTypes/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientType = await _context.ClientType.FindAsync(id);
            if (clientType == null)
            {
                return NotFound();
            }
            return View(clientType);
        }

        // POST: ClientTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("ClientTypeId,Category")] ClientType clientType)
        {
            if (id != clientType.ClientTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientTypeExists(clientType.ClientTypeId))
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
            return View(clientType);
        }

        // GET: ClientTypes/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientType = await _context.ClientType
                .FirstOrDefaultAsync(m => m.ClientTypeId == id);
            if (clientType == null)
            {
                return NotFound();
            }

            return View(clientType);
        }

        // POST: ClientTypes/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientType = await _context.ClientType.FindAsync(id);
            _context.ClientType.Remove(clientType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientTypeExists(int id)
        {
            return _context.ClientType.Any(e => e.ClientTypeId == id);
        }
    }
}
