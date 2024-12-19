using System.Data.Entity.Migrations;
using Tech2019.DataAccessLayer.Context;
using Tech2019.DataAccessLayer.SeedData;

namespace Tech2019.DataAccessLayer.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Tech2019.DataAccessLayer.Context.TechDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TechDBContext context)
        {
            //Task.Run(async () => await SeedDataGenerator.SeedAsync()).Wait();
            SeedDataGenerator.SeedAsync().Wait();
        }
    }
}
