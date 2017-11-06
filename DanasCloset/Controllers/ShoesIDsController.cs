using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DanasCloset.Models;

namespace DanasCloset.Controllers
{
    public class ShoesIDsController : Controller
    {
        private DanasClosetEntities db = new DanasClosetEntities();

        // GET: ShoesIDs
        public ActionResult Index()
        {
            return View(db.ShoesIDs.ToList());
        }

        // GET: ShoesIDs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoesID shoesID = db.ShoesIDs.Find(id);
            if (shoesID == null)
            {
                return HttpNotFound();
            }
            return View(shoesID);
        }

        // GET: ShoesIDs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShoesIDs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShoesID1,Name,Photo,Type,Color,Season,Occasion")] ShoesID shoesID)
        {
            if (ModelState.IsValid)
            {
                db.ShoesIDs.Add(shoesID);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shoesID);
        }

        // GET: ShoesIDs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoesID shoesID = db.ShoesIDs.Find(id);
            if (shoesID == null)
            {
                return HttpNotFound();
            }
            return View(shoesID);
        }

        // POST: ShoesIDs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShoesID1,Name,Photo,Type,Color,Season,Occasion")] ShoesID shoesID)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shoesID).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shoesID);
        }

        // GET: ShoesIDs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoesID shoesID = db.ShoesIDs.Find(id);
            if (shoesID == null)
            {
                return HttpNotFound();
            }
            return View(shoesID);
        }

        // POST: ShoesIDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShoesID shoesID = db.ShoesIDs.Find(id);
            db.ShoesIDs.Remove(shoesID);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
