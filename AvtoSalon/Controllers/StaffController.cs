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
    public class StaffController : Controller
    {
        DealershipEntities db = new DealershipEntities();

        // GET: Staff
        public ActionResult Index()
        {
            return View(db.Staff.ToList());
        }

        //Details
        [HttpGet]
        public ActionResult Details(int? id)
        {
            return View(db.Staff.Find(id));
        }

        //Edit
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (db.Staff.Find(id) == null)
            {
                return HttpNotFound();
            }
            ViewBag.Role = new SelectList(db.Role, "ID", "type");
            ViewBag.Room = new SelectList(db.Type_room, "ID", "type");
            return View(db.Staff.Find(id));
        }

        //Edit post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, fname, lname, RoleID, Type_roomID")] Staff Cl)
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
            ViewBag.Role = new SelectList(db.Role, "ID", "type");
            ViewBag.Room = new SelectList(db.Type_room, "ID", "type");
            return View();
        }

        //Сreate post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID, fname, lname, RoleID, Type_roomID")] Staff Cl)
        {

            if (ModelState.IsValid)
            {
                db.Staff.Add(Cl);
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
            if (db.Staff.Find(id) == null)
            {
                return HttpNotFound();
            }
            return View(db.Staff.Find(id));
        }

        //Delete post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Staff Cl = db.Staff.Find(id);
            db.Staff.Remove(Cl);
            db.SaveChanges();
            return RedirectToAction("/");
        }
    }
}