using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using TheCanteen.Models.Canteen;
using TheCanteen.Models.Canteen.PointOfSale;

namespace TheCanteen.Controllers.PointOfSale
{
	public class SalesController : Controller
	{
		private ICanteenContext db;

		public SalesController(ICanteenContext db)
		{
			this.db = db;
		}

		// GET: Sales
		public ActionResult Index()
		{
			return View(db.Sales.ToList());
		}

		// GET: Canteens/Create
		public ActionResult Create()
		{
			ViewBag.CanteenId = new SelectList(db.Canteens.ToList(), "Id", "Name");
			ViewBag.CustomerId = new SelectList(db.Customers.ToList(), "Id", "Name");
			//ViewBag.ProductDefinitions = new SelectList(db.ProductDefinitions, "Id", "Name");
			ViewBag.CanteenProducts = new SelectList(db.CanteenProducts.ToList(), "ProductDefinitionId", "Product.Name");
			return View();
		}

		// POST: CanteenProducts/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Sale sale)
		{
			var productArray = JsonConvert.DeserializeObject<IEnumerable<SaleProduct>>(Request["productsJson"].ToString());

			if (ModelState.IsValid)
			{
				sale.Transactions = GenerateTransactions(sale, productArray);
				db.Sales.Add(sale);
				db.Transactions.AddRange(sale.Transactions);
				db.SaveChanges();
			}

			ViewBag.CanteenId = new SelectList(db.Canteens.ToList(), "Id", "Name");
			ViewBag.CustomerId = new SelectList(db.Customers.ToList(), "Id", "Name");
			ViewBag.CanteenProducts = new SelectList(db.CanteenProducts.ToList(), "ProductDefinitionId", "Product.Name");
			return View(sale);
		}

		private IEnumerable<Transaction> GenerateTransactions(Sale sale, IEnumerable<SaleProduct> products)
		{
			return  products.Select(p => new Transaction
			{
				Sale = sale,
				CanteenId = sale.CanteenId,
				ProductDefinitionId = p.ProductId,
				Quantity = p.Quantity
			});
		}

		private class SaleProduct
		{
			public int ProductId { get; set; }
			public string ProductName { get; set; }
			public int Quantity { get; set; }
		}
	}

	
}