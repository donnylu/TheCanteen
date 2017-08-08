using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Threading;
using System.Threading.Tasks;
using TheCanteen.Models.Canteen.Customers;
using TheCanteen.Models.Canteen.Inventory;
using TheCanteen.Models.Canteen.PointOfSale;

namespace TheCanteen.Models.Canteen
{
	public interface ICanteenContext
	{
		DbSet<Canteen> Canteens { get; set; }
		DbSet<ProductDefinition> ProductDefinitions { get; set; }
		DbSet<CanteenProduct> CanteenProducts { get; set; }
		DbSet<Customer> Customers { get; set; }
		DbSet<Transaction> Transactions { get; set; }

		DbSet<Sale> Sales { get; set; }

		Database Database { get; }
		DbChangeTracker ChangeTracker { get; }
		DbContextConfiguration Configuration { get; }
		void Dispose();
		DbEntityEntry Entry(object entity);
		DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
		bool Equals(object obj);
		int GetHashCode();
		Type GetType();
		IEnumerable<DbEntityValidationResult> GetValidationErrors();
		int SaveChanges();
		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
		Task<int> SaveChangesAsync();
		DbSet Set(Type entityType);
		DbSet<TEntity> Set<TEntity>() where TEntity : class;
		string ToString();
	}
}