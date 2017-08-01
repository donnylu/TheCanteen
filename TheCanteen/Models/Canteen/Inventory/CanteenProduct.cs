﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TheCanteen.Models.Canteen.Inventory
{
    public class CanteenProduct
    {
        [Key, ForeignKey("Canteen")]
        public int CanteenId { get; set; }
        [ Key, ForeignKey("Product")]
        public int ProductDefinitionId { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }

        public virtual Canteen Canteen { get; set; }

        public virtual ProductDefinition Product { get; set; }
    }
}