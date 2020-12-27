using AvtoSalon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;

namespace AvtoSalon.Controllers
{
    public class AccessoryController : Controller
    {

        DealershipEntities db = new DealershipEntities();

        // GET: Accessory
        public ActionResult Index()
        {
            return View(db.Accessory.ToList());
        }

        //Details
        [HttpGet]
        public ActionResult Details(int? id)
        {
            return View(db.Accessory.Find(id));
        }

        //Edit
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (db.Accessory.Find(id) == null)
            {
                return HttpNotFound();
            }
            return View(db.Accessory.Find(id));
        }

        //Edit post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,type")] Accessory Cl)
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
            return View();
        }

        //Сreate post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,type")] Accessory Cl)
        {

            if (ModelState.IsValid)
            {
                db.Accessory.Add(Cl);
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
            if (db.Accessory.Find(id) == null)
            {
                return HttpNotFound();
            }
            return View(db.Accessory.Find(id));
        }

        //Delete post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accessory Cl = db.Accessory.Find(id);
            db.Accessory.Remove(Cl);
            db.SaveChanges();
            return RedirectToAction("/");
        }
    }
}