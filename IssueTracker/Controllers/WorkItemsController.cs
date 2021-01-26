using IssueTracker.DbAccessContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace IssueTracker.Controllers
{
    public class WorkItemsController : Controller
    {
        private readonly PostgreContext _context;

        public WorkItemsController(PostgreContext context)
        {
            _context = context;
        }
        // GET: WorkItemsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: WorkItemsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WorkItemsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkItemsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WorkItemsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WorkItemsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WorkItemsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WorkItemsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        } 
       
        [HttpGet]
        public JsonResult GetWorkItemsByIteration(int iterationId)
        {
            var result = _context.WorkItem.Where(w => w.IterationId == iterationId).ToList();
            return Json(result);
        }
    }
}
