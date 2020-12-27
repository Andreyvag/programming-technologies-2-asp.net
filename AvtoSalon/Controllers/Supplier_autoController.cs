using AvtoSalon.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AvtoSalon.Controllers
{
    public class Supplier_autoController : Controller
    {
        DealershipEntities db = new DealershipEntities();

        // GET: Supplier_auto
        public ActionResult Index()
        {
            return View(db.Supplier_auto.ToList());
        }

        //Details
        [HttpGet]
        public ActionResult Details(int? id)
        {
            return View(db.Supplier_auto.Find(id));
        }

        //Edit
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (db.Supplier_auto.Find(id) == null)
            {
                return HttpNotFound();
            }
            ViewBag.Role = new SelectList(db.Staff, "ID", "fname", "lname");
            return View(db.Supplier_auto.Find(id));
        }

        //Edit post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, date, StaffID")] Supplier_auto Cl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Cl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("/");
            }
            return View(Cl);
        }

        //Сreate
        public ActionResult Create()
        {
            ViewBag.Role = new SelectList(db.Staff, "ID", "fname", "lname");
            return View();
        }

        //Сreate post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID, date, StaffID")] Supplier_auto Cl)
        {

            if (ModelState.IsValid)
            {
                db.Supplier_auto.Add(Cl);
                db.SaveChanges();
                return RedirectToAction("/");
            }
            return View(Cl);
        }

        //Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (db.Supplier_auto.Find(id) == null)
            {
                return HttpNotFound();
            }
            return View(db.Supplier_auto.Find(id));
        }

        //Delete post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supplier_auto Cl = db.Supplier_auto.Find(id);
            db.Supplier_auto.Remove(Cl);
            db.SaveChanges();
            return RedirectToAction("/");
        }
    }
}