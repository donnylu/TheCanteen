using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheCanteen.Models.Canteen;
using TheCanteen.Models.Canteen.Customers;

namespace TheCanteen.Controllers.Customers
{
	public class CustomerCreditsController : Controller
	{
		private CanteenContext db = new CanteenContext();

		// GET: CustomerCredits
		public ActionResult Index()
		{
			var customerCredits = db.CustomerCredits.Include(c => c.Canteen).Include(c => c.Customer);
			return View(customerCredits.ToList());
		}

		// GET: CustomerCredits/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			CustomerCredit customerCredit = db.CustomerCredits.Find(id);
			if (customerCredit == null)
			{
				return HttpNotFound();
			}
			return View(customerCredit);
		}

		// GET: CustomerCredits/Create
		public ActionResult Create()
		{
			ViewBag.CanteenId = new SelectList(db.Canteens, "Id", "Name");
			ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName");
			return View();
		}

		// POST: CustomerCredits/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "CanteenId,CustomerId,Credit")] CustomerCredit customerCredit)
		{
			if (ModelState.IsValid)
			{
				db.CustomerCredits.Add(customerCredit);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.CanteenId = new SelectList(db.Canteens, "Id", "Name", customerCredit.CanteenId);
			ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName", customerCredit.CustomerId);
			return View(customerCredit);
		}

		// GET: CustomerCredits/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			CustomerCredit customerCredit = db.CustomerCredits.Find(id);
			if (customerCredit == null)
			{
				return HttpNotFound();
			}
			ViewBag.CanteenId = new SelectList(db.Canteens, "Id", "Name", customerCredit.CanteenId);
			ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName", customerCredit.CustomerId);
			return View(customerCredit);
		}

		// POST: CustomerCredits/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "CanteenId,CustomerId,Credit")] CustomerCredit customerCredit)
		{
			if (ModelState.IsValid)
			{
				db.Entry(customerCredit).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.CanteenId = new SelectList(db.Canteens, "Id", "Name", customerCredit.CanteenId);
			ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName", customerCredit.CustomerId);
			return View(customerCredit);
		}

		// GET: CustomerCredits/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			CustomerCredit customerCredit = db.CustomerCredits.Find(id);
			if (customerCredit == null)
			{
				return HttpNotFound();
			}
			return View(customerCredit);
		}

		// POST: CustomerCredits/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			CustomerCredit customerCredit = db.CustomerCredits.Find(id);
			db.CustomerCredits.Remove(customerCredit);
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
