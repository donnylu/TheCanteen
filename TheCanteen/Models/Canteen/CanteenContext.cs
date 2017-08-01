using System.Data.Entity;
using TheCanteen.Models.Canteen.Customers;
using TheCanteen.Models.Canteen.Inventory;

namespace TheCanteen.Models.Canteen
{
	public class CanteenContext : DbContext, ICanteenContext
	{
		public DbSet<Canteen> Canteens { get; set; }
		public DbSet<ProductDefinition> ProductDefinitions { get; set; }
		public DbSet<CanteenProduct> CanteenProducts { get; set; }

		public DbSet<Customer> Customers { get; set; }

		public System.Data.Entity.DbSet<TheCanteen.Models.Canteen.Customers.CustomerCredit> CustomerCredits { get; set; }
	}
}