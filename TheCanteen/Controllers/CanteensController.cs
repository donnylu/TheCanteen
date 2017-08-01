using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheCanteen.Models.Canteen;

namespace TheCanteen.Controllers
{
	public class CanteensController : Controller
	{
		private ICanteenContext db;

		public CanteensController(ICanteenContext db)
		{
			this.db = db;
		}

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
			Canteen Canteen = db.Canteens.Find(id);
			if (Canteen == null)
			{
				return HttpNotFound();
			}
			return View(Canteen);
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
		public ActionResult Create([Bind(Include = "Id,Name")] Canteen Canteen)
		{
			if (ModelState.IsValid)
			{
				db.Canteens.Add(Canteen);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(Canteen);
		}

		// GET: Canteens/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Canteen Canteen = db.Canteens.Find(id);
			if (Canteen == null)
			{
				return HttpNotFound();
			}
			return View(Canteen);
		}

		// POST: Canteens/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Name")] Canteen Canteen)
		{
			if (ModelState.IsValid)
			{
				db.Entry(Canteen).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(Canteen);
		}

		// GET: Canteens/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Canteen Canteen = db.Canteens.Find(id);
			if (Canteen == null)
			{
				return HttpNotFound();
			}
			return View(Canteen);
		}

		// POST: Canteens/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Canteen Canteen = db.Canteens.Find(id);
			db.Canteens.Remove(Canteen);
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
