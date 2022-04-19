using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class PlaceContext : DbContext
    {
        public PlaceContext()
        {
        }

        public PlaceContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Area> Areas { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Place> Places { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-6149JFK;Initial Catalog=ForestPlaces;Integrated Security=True;Pooling=False");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
