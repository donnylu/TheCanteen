using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TheCanteen.Models.Canteen.Customers;

namespace TheCanteen.Models.Canteen.PointOfSale
{
	public class Sale
	{
		[Key]
		public int Id { get; set; }
		[ForeignKey("Canteen")]
		public int CanteenId { get; set; }
		[ForeignKey("Customer")]
		public int CustomerId { get; set; }

		public IEnumerable<Transaction> Transactions { get; set; }
		public decimal Total { get; set; }

		public Customer Customer { get; set; }
		public Canteen Canteen { get; set; }
	}
}