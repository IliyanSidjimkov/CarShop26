using CarShop26.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarShop26.Data.Configuration
{
    public class CarEntityConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> entity)
        {
            entity
               .Property(c => c.Price)
               .HasPrecision(18, 2);
        }
    }
}
