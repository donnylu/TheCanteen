using System.Data.Entity;
using TheCanteen.Models.Canteen.Inventory;

namespace TheCanteen.Models.Canteen
{
    public class CanteenContext : DbContext, ICanteenContext
    {
        public DbSet<Canteen> Canteens { get; set; }
        public DbSet<ProductDefinition> ProductDefinitions { get; set; }
    }
}