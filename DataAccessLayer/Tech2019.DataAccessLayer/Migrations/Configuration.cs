using System.Data.Entity.Migrations;
using Tech2019.DataAccessLayer.Context;
using Tech2019.DataAccessLayer.SeedData;

namespace Tech2019.DataAccessLayer.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TechDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TechDBContext context)
        {
            SeedDataGenerator.SeedAsync().Wait();
        }
    }
}
