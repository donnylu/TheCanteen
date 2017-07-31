using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheCanteen.Models;

namespace TheCanteen.Controllers
{
    public class CanteensController : Controller
    {
        private CanteenContext db = new CanteenContext();

        public CanteensController()
        {

        }

        // GET: Canteens
        public ActionResult Index()
        {
            return View(db.Canteens.ToList());
        }

        // GET: Canteens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntityCanteen entityCanteen = db.Canteens.Find(id);
            if (entityCanteen == null)
            {
                return HttpNotFound();
            }
            return View(entityCanteen);
        }

        // GET: Canteens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Canteens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] EntityCanteen entityCanteen)
        {
            if (ModelState.IsValid)
            {
                db.Canteens.Add(entityCanteen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(entityCanteen);
        }

        // GET: Canteens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntityCanteen entityCanteen = db.Canteens.Find(id);
            if (entityCanteen == null)
            {
                return HttpNotFound();
            }
            return View(entityCanteen);
        }

        // POST: Canteens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] EntityCanteen entityCanteen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entityCanteen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(entityCanteen);
        }

        // GET: Canteens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntityCanteen entityCanteen = db.Canteens.Find(id);
            if (entityCanteen == null)
            {
                return HttpNotFound();
            }
            return View(entityCanteen);
        }

        // POST: Canteens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EntityCanteen entityCanteen = db.Canteens.Find(id);
            db.Canteens.Remove(entityCanteen);
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
