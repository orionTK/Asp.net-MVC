﻿using PagedList;
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
    public class RoleController : Controller
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

            var list_p = from p in _db.Roles
                         select p;

            //Search
            if (!String.IsNullOrEmpty(searchString))
            {
                list_p = list_p.Where(s => s.RoleName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    list_p = list_p.OrderByDescending(s => s.RoleName);
                    break;
                case "Date":
                    list_p = list_p.OrderBy(s => s.TimeCreated);
                    break;
                case "date_desc":
                    list_p = list_p.OrderByDescending(s => s.TimeCreated);
                    break;
                default:
                    list_p = list_p.OrderBy(s => s.RoleName);
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

            var p = _db.Roles.Find(id);

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
        public ActionResult Create(Role r)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    // TODO: Add insert logic here
                    r.TimeCreated = DateTime.Now;
                    _db.Roles.Add(r);
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

            var r = _db.Roles.Find(id);

            if (r == null)
            {
                return HttpNotFound();
            }

            return View(r);
        }

        // POST: Promotion/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Role role)
        {

            var r = _db.Roles.Find(id);
            try
            {
                r.RoleName = role.RoleName;
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
            return View(_db.Roles.Find(id));
        }

        // POST: Promotion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var p = _db.Roles.Find(id);
                _db.Roles.Remove(p);
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
