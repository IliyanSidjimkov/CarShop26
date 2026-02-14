
namespace CarShop26.Data
{
    using CarShop26.Data.Configuration;
    using CarShop26.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    public class CarShop26DbContext : IdentityDbContext
    {
        public CarShop26DbContext(DbContextOptions<CarShop26DbContext> options)
            : base(options)
        {


        }

        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Favourites> Favourites { get; set; } = null!;

        public override int SaveChanges()
        {
            this.ChangeTracker
                .Entries<Car>()
                .Where(CarAdded => CarAdded.State == EntityState.Added)
                .ToList()
                .ForEach(CarAdded =>
                {
                    if (CarAdded == default)
                    {
                        CarAdded.Entity.CreatedOn = DateTime.UtcNow;
                    }

                });
            return base.SaveChanges();
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(CarShop26DbContext).Assembly);
            

        }

    }
}
