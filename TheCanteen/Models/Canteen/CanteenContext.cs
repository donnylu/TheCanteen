using System.Data.Entity;
using TheCanteen.Models.Canteen.Customers;
using TheCanteen.Models.Canteen.Inventory;
using TheCanteen.Models.Canteen.PointOfSale;

namespace TheCanteen.Models.Canteen
{
	public class CanteenContext : DbContext, ICanteenContext
	{
		public DbSet<Canteen> Canteens { get; set; }
		public DbSet<ProductDefinition> ProductDefinitions { get; set; }
		public DbSet<CanteenProduct> CanteenProducts { get; set; }

		public DbSet<Customer> Customers { get; set; }

		public DbSet<CustomerCredit> CustomerCredits { get; set; }

		public DbSet<Transaction> Transactions { get; set; }

		public DbSet<Sale> Sales { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Transaction>().HasRequired(t => t.Sale).WithMany().WillCascadeOnDelete(false);
			modelBuilder.Entity<Transaction>().HasRequired(t => t.CanteenProduct).WithMany().WillCascadeOnDelete(false);
		}
	}
}