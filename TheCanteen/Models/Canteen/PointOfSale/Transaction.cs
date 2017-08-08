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
		[ForeignKey("CanteenProduct"), Column(Order=0)]
		public int CanteenId { get; set; }
		[ForeignKey("CanteenProduct"), Column(Order=1)]
		public int ProductDefinitionId { get; set; }
		[ForeignKey("Sale")]
		public int SaleId { get; set; }

		public int Quantity { get; set; }
		public decimal ProductPrice { get; set; }

		public CanteenProduct CanteenProduct { get; set; }
		public Sale Sale { get; set; }
	}
}