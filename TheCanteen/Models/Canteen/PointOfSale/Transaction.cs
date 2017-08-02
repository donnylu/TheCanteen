using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheCanteen.Models.Canteen.Customers;
using TheCanteen.Models.Canteen.Inventory;

namespace TheCanteen.Models.Canteen.PointOfSale
{
	public class Transaction
	{
		[Key]
		public int Id { get; set; }
		[ForeignKey("Customer")]
		public int CustomerId { get; set; }
		[ForeignKey("CanteenProduct"), Column(Order=0)]
		public int CanteenId { get; set; }
		[ForeignKey("CanteenProduct"), Column(Order=1)]
		public int CanteenProductId { get; set; }

		public Customer Customer { get; set; }
		public CanteenProduct CanteenProduct { get; set; }
	}
}