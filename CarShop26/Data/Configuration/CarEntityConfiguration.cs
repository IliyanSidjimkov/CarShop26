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
                 new Car {
                    Id = 2,
                    Brand = "Audi",
                    Model = "A3",
                    Year = 2020,
                    Price = 20000.00m,
                    Mileage = 90000,
                    FuelType = FuelType.Diesel,
                    GearboxType = GearboxType.Automatic,
                    ImageUrl = "https://cdn.images.autoexposure.co.uk/AETA31676/AETV29758780_1e.jpg",
                    UserId = "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f",
                    CityId = 5,
                    CategoryId = 9 },
                 new Car {
                    Id = 3,
                    Brand = "Audi",
                    Model = "A5",
                    Year = 2018,
                    Price = 18000.00m,
                    Mileage = 150000,
                    FuelType = FuelType.Petrol,
                    GearboxType = GearboxType.Manual,
                    ImageUrl = "https://f7432d8eadcf865aa9d9-9c672a3a4ecaaacdf2fee3b3e6fd2716.ssl.cf3.rackcdn.com/C3312/U574/IMG_9463-large.jpg",
                    UserId = "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f",
                    CityId = 4,
                    CategoryId = 11 },
                 new Car {
                    Id = 4,
                    Brand = "Audi",
                    Model = "A6",
                    Year = 2013,
                    Price = 14000.00m,
                    Mileage = 185000,
                    FuelType = FuelType.Diesel,
                    GearboxType = GearboxType.Automatic,
                    ImageUrl = "https://ahq-img.b-cdn.net/1122/v4461-13.jpg?width=1800",
                    UserId = "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f",
                    CityId = 6,
                    CategoryId = 4 },
                  new Car {
                    Id = 5,
                    Brand = "Audi",
                    Model = "RS6",
                    Year = 2019,
                    Price = 90000.00m,
                    Mileage = 155000,
                    FuelType = FuelType.Petrol,
                    GearboxType = GearboxType.Automatic,
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSMtrUBtcK5dc8u9urUVoaWrpmd_HGtMx_OwA&s",
                    UserId = "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f",
                    CityId = 2,
                    CategoryId = 4 }
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
