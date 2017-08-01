using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheCanteen.Models.Canteen.Inventory
{
    [Table("ProductDefinitions")]
    public class ProductDefinition
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}