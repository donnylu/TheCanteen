using System;
using System.Data.Entity;

namespace TheCanteen.Models.Canteen
{
    public class EntityCanteen : ICanteen
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CanteenContext : DbContext, ICanteenContext
    {
        public DbSet<EntityCanteen> Canteens { get; set; }
    }
}