namespace taka3.Migrations
{
	using Microsoft.AspNet.Identity;
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;
	using taka3.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<taka3.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(taka3.Models.ApplicationDbContext context)
        {
			//Reyna að setja inn fastann user í kerfið	-Védís
			/*var passwordHash = new PasswordHasher();
			string password = passwordHash.HashPassword("Password@123");
			
				var user = new ApplicationUser
				{
					UserName = "username",
					Email = "Steve@Jobs,com",
					PasswordHash = password,
					FirstName = "John",
					LastName = "Smith",
					Country = "Kazakhstan",
					BirthDate = DateTime.Parse("1988-02-05 17:30:00"),
					Gender = "male"
				};
				context.Users.Add(user);

			context.SaveChanges();*/

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

