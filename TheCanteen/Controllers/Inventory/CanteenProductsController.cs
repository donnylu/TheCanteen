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

namespace TheCanteen.Controllers.Inventory
{
	public class CanteenProductsController : Controller
	{
		private CanteenContext db = new CanteenContext();

		// GET: CanteenProducts
		public ActionResult Index()
		{
			var canteenProducts = db.CanteenProducts.Include(c => c.Canteen).Include(c => c.Product);
			return View(canteenProducts.ToList());
		}

		// GET: CanteenProducts/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			CanteenProduct canteenProduct = db.CanteenProducts.Find(id);
			if (canteenProduct == null)
			{
				return HttpNotFound();
			}
			return View(canteenProduct);
		}

		// GET: CanteenProducts/Create
		public ActionResult Create()
		{
			ViewBag.CanteenId = new SelectList(db.Canteens, "Id", "Name");
			ViewBag.ProductDefinitionId = new SelectList(db.ProductDefinitions, "Id", "Name");
			return View();
		}

		// POST: CanteenProducts/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "CanteenId,ProductDefinitionId,Stock,Price")] CanteenProduct canteenProduct)
		{
			if (ModelState.IsValid)
			{
				db.CanteenProducts.Add(canteenProduct);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.CanteenId = new SelectList(db.Canteens, "Id", "Name", canteenProduct.CanteenId);
			ViewBag.ProductDefinitionId = new SelectList(db.ProductDefinitions, "Id", "Name", canteenProduct.ProductDefinitionId);
			return View(canteenProduct);
		}

		// GET: CanteenProducts/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			CanteenProduct canteenProduct = db.CanteenProducts.Find(id);
			if (canteenProduct == null)
			{
				return HttpNotFound();
			}
			ViewBag.CanteenId = new SelectList(db.Canteens, "Id", "Name", canteenProduct.CanteenId);
			ViewBag.ProductDefinitionId = new SelectList(db.ProductDefinitions, "Id", "Name", canteenProduct.ProductDefinitionId);
			return View(canteenProduct);
		}

		// POST: CanteenProducts/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "CanteenId,ProductDefinitionId,Stock,Price")] CanteenProduct canteenProduct)
		{
			if (ModelState.IsValid)
			{
				db.Entry(canteenProduct).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.CanteenId = new SelectList(db.Canteens, "Id", "Name", canteenProduct.CanteenId);
			ViewBag.ProductDefinitionId = new SelectList(db.ProductDefinitions, "Id", "Name", canteenProduct.ProductDefinitionId);
			return View(canteenProduct);
		}

		// GET: CanteenProducts/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			CanteenProduct canteenProduct = db.CanteenProducts.Find(id);
			if (canteenProduct == null)
			{
				return HttpNotFound();
			}
			return View(canteenProduct);
		}

		// POST: CanteenProducts/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			CanteenProduct canteenProduct = db.CanteenProducts.Find(id);
			db.CanteenProducts.Remove(canteenProduct);
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
