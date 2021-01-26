using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IssueTracker.DbAccessContext;
using IssueTracker.Models;

namespace IssueTracker.Controllers
{
    public class WorkItemTypesController : Controller
    {
        private readonly PostgreContext _context;

        public WorkItemTypesController(PostgreContext context)
        {
            _context = context;
        }

        // GET: WorkItemTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkItemType.ToListAsync());
        }

        // GET: WorkItemTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workItemType = await _context.WorkItemType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workItemType == null)
            {
                return NotFound();
            }

            return View(workItemType);
        }

        // GET: WorkItemTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkItemTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id")] WorkItemType workItemType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workItemType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workItemType);
        }

        // GET: WorkItemTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workItemType = await _context.WorkItemType.FindAsync(id);
            if (workItemType == null)
            {
                return NotFound();
            }
            return View(workItemType);
        }

        // POST: WorkItemTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id")] WorkItemType workItemType)
        {
            if (id != workItemType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workItemType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkItemTypeExists(workItemType.Id))
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
            return View(workItemType);
        }

        // GET: WorkItemTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workItemType = await _context.WorkItemType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workItemType == null)
            {
                return NotFound();
            }

            return View(workItemType);
        }

        // POST: WorkItemTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workItemType = await _context.WorkItemType.FindAsync(id);
            _context.WorkItemType.Remove(workItemType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkItemTypeExists(int id)
        {
            return _context.WorkItemType.Any(e => e.Id == id);
        }

        [HttpPost]
        public JsonResult GetAllWorkItemType()
        {
            var result = _context.WorkItemType.ToList();
            return Json(result);
        }
    }
}
