using System;

namespace TheCanteen.Models
{
    public interface ICanteen
    {
        Guid CanteenId { get; set; }
        string CanteenName { get; set; }
    }
}