
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using SuperWare.Models;
namespace SuperWare.Controllers
{
    public class ProductController : Controller
    {

        SuperWareDbContext _db = new SuperWareDbContext();

        // GET: Promotion
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

            var list_p = from p in _db.Products
                         select p;

            //Search
            if (!String.IsNullOrEmpty(searchString))
            {
                list_p = list_p.Where(s => s.NameEnglish.Contains(searchString)
                || s.NameVietNamese.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    list_p = list_p.OrderByDescending(s => s.NameVietNamese);
                    break;
                case "En":
                    list_p = list_p.OrderBy(s => s.NameEnglish);
                    break;
                case "en_desc":
                    list_p = list_p.OrderByDescending(s => s.NameEnglish);
                    break;
                case "Date":
                    list_p = list_p.OrderBy(s => s.TimeCreated);
                    break;
                case "date_desc":
                    list_p = list_p.OrderByDescending(s => s.TimeCreated);
                    break;
                default:
                    list_p = list_p.OrderBy(s => s.NameVietNamese);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(list_p.ToPagedList(pageNumber, pageSize));
        }

        // GET: Promotion/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var p = _db.Users.Find(id);

            if (p == null)
            {
                return HttpNotFound();
            }

            return View(p);
        }

        // GET: Promotion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Promotion/Create
        [HttpPost]
        public ActionResult Create(User u)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    // TODO: Add insert logic here
                    u.TimeCreated = DateTime.Now;
                    _db.Users.Add(u);
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

        // GET: Promotion/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var r = _db.Users.Find(id);

            if (r == null)
            {
                return HttpNotFound();
            }

            return View(r);
        }

        // POST: Promotion/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {

            var u = _db.Users.Find(id);
            try
            {
                u.UserName = user.UserName;
                u.Password = user.Password;
                _db.SaveChangesAsync();

                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Promotion/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_db.Warehouses.Find(id));
        }

        // POST: Promotion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var p = _db.Users.Find(id);
                _db.Users.Remove(p);
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