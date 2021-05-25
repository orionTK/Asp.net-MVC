using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SuperWare.Models;
using PagedList;
namespace SuperWare.Controllers
{
    public class PatternController : Controller
    {
        SuperWareDbContext _db = new SuperWareDbContext();

        
        // GET: Pattern
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page) 
        {
            //Sort
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var list_p = from p in _db.Patterns
                         select p;

            //Search
            if (!String.IsNullOrEmpty(searchString))
            {
                list_p = list_p.Where(s => s.PatternName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    list_p = list_p.OrderByDescending(s => s.PatternName);
                    break;
                case "Date":
                    list_p = list_p.OrderBy(s => s.TimeCreated);
                    break;
                case "date_desc":
                    list_p = list_p.OrderByDescending(s => s.TimeCreated);
                    break;
                default:
                    list_p = list_p.OrderBy(s => s.PatternName);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(list_p.ToPagedList(pageNumber, pageSize));
        }

        // GET: Pattern/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var p = _db.Patterns.Find(id);

            if (p == null)
            {
                return HttpNotFound();
            }

            return View(p);
        }

        // GET: Pattern/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pattern/Create
        [HttpPost]
        public ActionResult Create(Pattern p)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    // TODO: Add insert logic here
                    p.TimeCreated = DateTime.Now;
                    _db.Patterns.Add(p);
                    _db.SaveChangesAsync();
                return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View();
        }

        // GET: Pattern/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var p = _db.Patterns.Find(id);

            if (p == null)
            {
                return HttpNotFound();
            }

            return View(p);
        }

        // POST: Pattern/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Pattern pattern)
        {
            var p = _db.Patterns.Find(id);
            try
            {
                p.PatternName = pattern.PatternName;
                _db.SaveChangesAsync();

                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View(_db.Patterns.Find(id));
        }

        // POST: Pattern/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var p = _db.Patterns.Find(id);
            _db.Patterns.Remove(p);
            _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
