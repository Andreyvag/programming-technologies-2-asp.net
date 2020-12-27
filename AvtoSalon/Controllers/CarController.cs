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
    public class CarController : Controller
    {

        DealershipEntities db = new DealershipEntities();

        // GET: Car
        public ActionResult Index()
        {
            return View(db.Car.ToList());
        }

        //Details
        [HttpGet]
        public ActionResult Details(int? id)
        {
            return View(db.Car.Find(id));
        }

        //Edit
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (db.Car.Find(id) == null)
            {
                return HttpNotFound();
            }
            ViewBag.Equ = new SelectList(db.Equipment, "ID", "type");
            ViewBag.Supplier = new SelectList(db.Supplier_auto, "ID", "date");
            ViewBag.Personal = new SelectList(db.Staff, "ID", "fname", "lname");
            return View(db.Car.Find(id));
        }

        //Edit post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, Brand, Supplier_autoID, price, EquipmentID, StaffID")] Car Cl)
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
            ViewBag.Equ = new SelectList(db.Equipment, "ID", "type");
            ViewBag.Supplier = new SelectList(db.Supplier_auto, "ID", "date");
            ViewBag.Personal = new SelectList(db.Staff, "ID", "fname", "lname");
            return View();
        }

        //Сreate post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID, Brand, Supplier_autoID,  price, EquipmentID, StaffID")] Car Cl)
        {

            if (ModelState.IsValid)
            {
                db.Car.Add(Cl);
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
            if (db.Car.Find(id) == null)
            {
                return HttpNotFound();
            }
            return View(db.Car.Find(id));
        }

        //Delete post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car Cl = db.Car.Find(id);
            db.Car.Remove(Cl);
            db.SaveChanges();
            return RedirectToAction("/");
        }
    }
}