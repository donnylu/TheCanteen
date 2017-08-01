using System;
using System.Collections.Generic;
using TheCanteen.Models.Canteen.Inventory;

namespace TheCanteen.Models.Canteen
{
    public class EntityCanteen
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ProductDefinition> Products { get; set; }
    }
}