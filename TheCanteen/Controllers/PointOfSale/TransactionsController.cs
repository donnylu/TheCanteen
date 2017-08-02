﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TheCanteen.Models.Canteen;
using TheCanteen.Models.Canteen.PointOfSale;

namespace TheCanteen.Controllers.PointOfSale
{
	public class TransactionsController : Controller
	{
		private CanteenContext db = new CanteenContext();

		// GET: Transactions
		public ActionResult Index()
		{
			var transactions = db.Transactions.Include(t => t.CanteenProduct).Include(t => t.Customer);
			return View(transactions.ToList());
		}

		// GET: Transactions/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Transaction transaction = db.Transactions.Find(id);
			if (transaction == null)
			{
				return HttpNotFound();
			}
			return View(transaction);
		}

		// GET: Transactions/Create
		public ActionResult Create()
		{
			ViewBag.CanteenId = new SelectList(db.CanteenProducts, "CanteenId", "CanteenId");
			ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName");
			return View();
		}

		// POST: Transactions/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,CustomerId,CanteenId,CanteenProductId")] Transaction transaction)
		{
			if (ModelState.IsValid)
			{
				db.Transactions.Add(transaction);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.CanteenId = new SelectList(db.CanteenProducts, "CanteenId", "CanteenId", transaction.CanteenId);
			ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName", transaction.CustomerId);
			return View(transaction);
		}

		// GET: Transactions/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Transaction transaction = db.Transactions.Find(id);
			if (transaction == null)
			{
				return HttpNotFound();
			}
			ViewBag.CanteenId = new SelectList(db.CanteenProducts, "CanteenId", "CanteenId", transaction.CanteenId);
			ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName", transaction.CustomerId);
			return View(transaction);
		}

		// POST: Transactions/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,CustomerId,CanteenId,CanteenProductId")] Transaction transaction)
		{
			if (ModelState.IsValid)
			{
				db.Entry(transaction).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.CanteenId = new SelectList(db.CanteenProducts, "CanteenId", "CanteenId", transaction.CanteenId);
			ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName", transaction.CustomerId);
			return View(transaction);
		}

		// GET: Transactions/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Transaction transaction = db.Transactions.Find(id);
			if (transaction == null)
			{
				return HttpNotFound();
			}
			return View(transaction);
		}

		// POST: Transactions/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Transaction transaction = db.Transactions.Find(id);
			db.Transactions.Remove(transaction);
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