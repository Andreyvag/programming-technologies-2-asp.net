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
    public class ClientController : Controller
    {
        DealershipEntities db = new DealershipEntities();

        // GET: Client
        public ActionResult Index()
        {
            return View(db.Client.ToList());
        }

        //Details
        [HttpGet]
        public ActionResult Details(int? id)
        {
            return View(db.Client.Find(id));
        }

        //Edit
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (db.Client.Find(id) == null)
            {
                return HttpNotFound();
            }
            ViewBag.Avto = new SelectList(db.Car, "ID", "Brand");
            return View(db.Client.Find(id));
        }

        //Edit post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, fname, lname, phone, CarID")] Client Cl)
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
            ViewBag.Avto = new SelectList(db.Car, "ID", "Brand");
            return View();
        }

        //Сreate post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID, fname, lname, phone, CarID")] Client Cl)
        {

            if (ModelState.IsValid)
            {
                db.Client.Add(Cl);
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
            if (db.Client.Find(id) == null)
            {
                return HttpNotFound();
            }
            return View(db.Client.Find(id));
        }

        //Delete post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client Cl = db.Client.Find(id);
            db.Client.Remove(Cl);
            db.SaveChanges();
            return RedirectToAction("/");
        }
    }
}