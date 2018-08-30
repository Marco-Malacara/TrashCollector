namespace TrashCollector_Project.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Models.ApplicationDbContext context)
        {
            context.Employee.AddOrUpdate(x => x.Id,
                new Models.Employee() { Id = 1, FristName = "Marco", LastName = "Malacara", Zipcode = 53142}
            );
        }
    }
}
