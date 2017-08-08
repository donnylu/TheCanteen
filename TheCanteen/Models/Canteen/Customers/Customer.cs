﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheCanteen.Models.Canteen.Customers
{
	public class Customer
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public string Name => $"{FirstName} {LastName}";
	}
}