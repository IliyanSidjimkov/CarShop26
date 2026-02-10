using CarShop26.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarShop26.Data.Configuration
{
    public class CityEntityConfiguration : IEntityTypeConfiguration<City>
    {
        private readonly City[] cities = new City[]
        {
            new City()
            {
                Id = 1,
                CityName = "Sofia"
            },
            new City()
            {
                Id = 2,
                CityName = "Plovdiv"
            },
            new City()
            {
                Id = 3,
                CityName = "Varna"
            },
            new City()
            {
                Id = 4,
                CityName = "Burgas"
            },
            new City()
            {
                Id = 5,
                CityName = "Ruse"
            },
            new City()
            {
                Id = 6,
                CityName = "Blagoevgrad"
            },
             new City()
            {
                Id = 7,
                CityName = "Veliko Tarnovo"
            },
              new City()
            {
                Id = 8,
                CityName = "Vidin"
            }
        };

        public void Configure(EntityTypeBuilder<City> entity)
        {
            entity.HasData(cities);
        }
    }
}
