using CarShop26.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarShop26.Data.Configuration
{
    public class CarEntityConfiguration : IEntityTypeConfiguration<Car>
    {

        private readonly Car[] cars = new Car[]
            {
                new Car {
                    Id = 1, 
                    Brand = "Audi", 
                    Model = "A4", 
                    Year = 2015, 
                    Price = 15000.00m, 
                    Mileage = 120000, 
                    FuelType = FuelType.Diesel, 
                    GearboxType = GearboxType.Automatic, 
                    ImageUrl = "https://alarmsyst-bg.com/cdn/shop/files/audi-a4-b8-8k-facelift-2009-2015-1499x843_1024x1024.jpg?v=1747237269", 
                    UserId = "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f", 
                    CityId = 1, 
                    CategoryId = 8 },
            };

        public void Configure(EntityTypeBuilder<Car> entity)
        {
            entity.HasData(cars);

            entity
               .Property(c => c.Price)
               .HasPrecision(18, 2);
        }
    }
}
