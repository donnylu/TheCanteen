using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TheCanteen.Models.Canteen.Customers
{
	public class CustomerCredit
	{
		[Column(Order=0), Key, ForeignKey("Canteen")]
		public int CanteenId { get; set; }
		[Column(Order=1), Key, ForeignKey("Customer")]
		public int CustomerId { get; set; }
		public decimal Credit { get; set; }

		public Canteen Canteen { get; set; }
		public Customer Customer { get; set; }
	}
}