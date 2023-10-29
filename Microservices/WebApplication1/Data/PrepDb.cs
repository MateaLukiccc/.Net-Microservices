using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using(var seviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(seviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding data...");
                context.Platforms.AddRange(
                    new Platform()
                    {
                        Name=".Net",
                        Publisher="Microsoft",
                        Cost="120"
                    },
                    new Platform()
                    {
                        Name = ".Sql",
                        Publisher = "Seequel",
                        Cost = "20"
                    },
                    new Platform()
                    {
                        Name = "Kubernetes",
                        Publisher = "Cloud Native",
                        Cost = "120"
                    }
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data in our database");
            }

        }

    }
}
