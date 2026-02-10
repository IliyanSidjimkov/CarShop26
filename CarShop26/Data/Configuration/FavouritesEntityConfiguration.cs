using CarShop26.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarShop26.Data.Configuration
{
    public class FavouritesEntityConfiguration : IEntityTypeConfiguration<Favourites>
    {
        public void Configure(EntityTypeBuilder<Favourites> entity)
        {
            entity.HasOne(f => f.Car)
                  .WithMany()
                  .HasForeignKey(f => f.CarId)
                  .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(f => f.User)
                .WithMany()
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
