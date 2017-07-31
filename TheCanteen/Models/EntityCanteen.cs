using System;
using System.Data.Entity;

namespace TheCanteen.Models
{
    public class EntityCanteen : ICanteen
    {
        public Guid CanteenId { get; set; }
        public string CanteenName { get; set; }
    }

    public class CanteenContext : DbContext
    {
        public DbSet<EntityCanteen> Canteens { get; set; }
    }
}