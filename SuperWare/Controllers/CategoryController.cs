using PagedList;
using SuperWare.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SuperWare.Controllers
{
    public class CategoryController : Controller
    {
        SuperWareDbContext _db = new SuperWareDbContext();
        // GET: Category
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
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

            var list_c = from c in _db.Categories
                         select c;

            //Search
            if (!String.IsNullOrEmpty(searchString))
            {
                list_c = list_c.Where(s => s.CategoryName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    list_c = list_c.OrderByDescending(s => s.CategoryName);
                    break;
                case "Date":
                    list_c = list_c.OrderBy(s => s.TimeCreated);
                    break;
                case "date_desc":
                    list_c = list_c.OrderByDescending(s => s.TimeCreated);
                    break;
                default:
                    list_c = list_c.OrderBy(s => s.CategoryName);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(list_c.ToPagedList(pageNumber, pageSize));
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var c = _db.Categories.Find(id);

            if (c == null)
            {
                return HttpNotFound();
            }

            return View(c);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category c)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    // TODO: Add insert logic here
                    c.TimeCreated = DateTime.Now;
                    _db.Categories.Add(c);
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

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var c = _db.Categories.Find(id);

            if (c == null)
            {
                return HttpNotFound();
            }

            return View(c);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Category category)
        {
            var p = _db.Categories.Find(id);
            try
            {
                p.CategoryName = category.CategoryName;
                _db.SaveChangesAsync();

                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_db.Categories.Find(id));
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var p = _db.Categories.Find(id);
                _db.Categories.Remove(p);
                _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
