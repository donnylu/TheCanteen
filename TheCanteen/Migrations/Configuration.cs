namespace TheCanteen.Migrations
{
	using System.Data.Entity.Migrations;
	using TheCanteen.Models.Canteen;

	internal sealed class Configuration : DbMigrationsConfiguration<CanteenContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = true;
			ContextKey = "TheCanteen.Models.CanteenContext";
		}

		protected override void Seed(CanteenContext context)
		{
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data. E.g.
			//
			//    context.People.AddOrUpdate(
			//      p => p.FullName,
			//      new Person { FullName = "Andrew Peters" },
			//      new Person { FullName = "Brice Lambson" },
			//      new Person { FullName = "Rowan Miller" }
			//    );
			//
		}
	}
}
