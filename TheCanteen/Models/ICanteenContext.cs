using System.Data.Entity;

namespace TheCanteen.Models
{
    public interface ICanteenContext
    {
        DbSet<EntityCanteen> Canteens { get; set; }
    }
}