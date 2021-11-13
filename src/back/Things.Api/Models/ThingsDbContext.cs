using Microsoft.EntityFrameworkCore;

namespace Things.Api.Models
{
    public class ThingsDbContext : DbContext
    {
        public ThingsDbContext(DbContextOptions<ThingsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Thing> Units { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region seed db data

            var units = new[]
            {
                new Thing
                {
                    Id = "1"
                },
                new Thing
                {
                    Id = "2"
                }
            };

            #endregion

            modelBuilder.Entity<Thing>().HasData(units);

            base.OnModelCreating(modelBuilder);
        }
    }
}