using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TheCanteen.Models.Canteen.Inventory
{
	public class CanteenProduct
	{
		[Column(Order=0), Key, ForeignKey("Canteen")]
		public int CanteenId { get; set; }
		[Column(Order=1), Key, ForeignKey("Product")]
		public int ProductDefinitionId { get; set; }
		public int Stock { get; set; }
		public decimal Price { get; set; }
		public string Name => Product.Name;


		public virtual Canteen Canteen { get; set; }
		public virtual ProductDefinition Product { get; set; }
	}
}