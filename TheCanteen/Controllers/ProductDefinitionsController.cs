using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheCanteen.Models.Canteen;
using TheCanteen.Models.Canteen.Inventory;

namespace TheCanteen.Controllers
{
    public class ProductDefinitionsController : Controller
    {
        private ICanteenContext db;

        public ProductDefinitionsController(ICanteenContext db)
        {
            this.db = db;
        }

        // GET: ProductDefinitions
        public ActionResult Index()
        {
            return View(db.ProductDefinitions.ToList());
        }

        // GET: ProductDefinitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDefinition productDefinition = db.ProductDefinitions.Find(id);
            if (productDefinition == null)
            {
                return HttpNotFound();
            }
            return View(productDefinition);
        }

        // GET: ProductDefinitions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductDefinitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] ProductDefinition productDefinition)
        {
            if (ModelState.IsValid)
            {
                db.ProductDefinitions.Add(productDefinition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productDefinition);
        }

        // GET: ProductDefinitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDefinition productDefinition = db.ProductDefinitions.Find(id);
            if (productDefinition == null)
            {
                return HttpNotFound();
            }
            return View(productDefinition);
        }

        // POST: ProductDefinitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] ProductDefinition productDefinition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productDefinition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productDefinition);
        }

        // GET: ProductDefinitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDefinition productDefinition = db.ProductDefinitions.Find(id);
            if (productDefinition == null)
            {
                return HttpNotFound();
            }
            return View(productDefinition);
        }

        // POST: ProductDefinitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductDefinition productDefinition = db.ProductDefinitions.Find(id);
            db.ProductDefinitions.Remove(productDefinition);
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
