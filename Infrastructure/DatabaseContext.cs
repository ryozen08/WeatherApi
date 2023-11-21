using Microsoft.EntityFrameworkCore;
using Model;

namespace Infrastructure
{
    public class DatabaseContext : DbContext
    {
         public DbSet<CityWeather> CityWeathers { get; set; }

         public DbSet<City> Cities { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

         public void EnsureDatabaseCreated()
         {
             this.Database.EnsureCreated();
         }

    }
}