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
    public class WorkItemStatesController : Controller
    {
        private readonly PostgreContext _context;

        public WorkItemStatesController(PostgreContext context)
        {
            _context = context;
        }

        // GET: WorkItemStates
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkItemState.ToListAsync());
        }

        // GET: WorkItemStates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workItemState = await _context.WorkItemState
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workItemState == null)
            {
                return NotFound();
            }

            return View(workItemState);
        }

        // GET: WorkItemStates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkItemStates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id")] WorkItemState workItemState)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workItemState);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workItemState);
        }

        // GET: WorkItemStates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workItemState = await _context.WorkItemState.FindAsync(id);
            if (workItemState == null)
            {
                return NotFound();
            }
            return View(workItemState);
        }

        // POST: WorkItemStates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id")] WorkItemState workItemState)
        {
            if (id != workItemState.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workItemState);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkItemStateExists(workItemState.Id))
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
            return View(workItemState);
        }

        // GET: WorkItemStates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workItemState = await _context.WorkItemState
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workItemState == null)
            {
                return NotFound();
            }

            return View(workItemState);
        }

        // POST: WorkItemStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workItemState = await _context.WorkItemState.FindAsync(id);
            _context.WorkItemState.Remove(workItemState);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkItemStateExists(int id)
        {
            return _context.WorkItemState.Any(e => e.Id == id);
        }

        [HttpPost]
        public JsonResult GetAllWorkItemState()
        {
            var result = _context.WorkItemState.ToList();
            return Json(result);
        }
    }
}
