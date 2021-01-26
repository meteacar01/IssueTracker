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
    public class IterationsController : Controller
    {
        private readonly PostgreContext _context;

        public IterationsController(PostgreContext context)
        {
            _context = context;
        }

        // GET: Iterations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Iteration.ToListAsync());
        }

        // GET: Iterations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iteration = await _context.Iteration
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iteration == null)
            {
                return NotFound();
            }

            return View(iteration);
        }

        // GET: Iterations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Iterations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id")] Iteration iteration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iteration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(iteration);
        }

        // GET: Iterations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iteration = await _context.Iteration.FindAsync(id);
            if (iteration == null)
            {
                return NotFound();
            }
            return View(iteration);
        }

        // POST: Iterations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id")] Iteration iteration)
        {
            if (id != iteration.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iteration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IterationExists(iteration.Id))
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
            return View(iteration);
        }

        // GET: Iterations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iteration = await _context.Iteration
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iteration == null)
            {
                return NotFound();
            }

            return View(iteration);
        }

        // POST: Iterations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var iteration = await _context.Iteration.FindAsync(id);
            _context.Iteration.Remove(iteration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IterationExists(int id)
        {
            return _context.Iteration.Any(e => e.Id == id);
        }

        [HttpPost]
        public JsonResult GetAllIteration()
        {
            var result = _context.Iteration.ToList();
            return Json(result);
        }
    }
}
