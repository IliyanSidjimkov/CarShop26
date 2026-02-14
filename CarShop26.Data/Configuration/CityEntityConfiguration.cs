using CarShop26.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarShop26.Data.Configuration
{
    public class CityEntityConfiguration : IEntityTypeConfiguration<City>
    {
        private readonly City[] cities = new City[]
{
           new City() { Id = 1, CityName = "Sofia" },
           new City() { Id = 2, CityName = "Plovdiv" },
           new City() { Id = 3, CityName = "Varna" },
           new City() { Id = 4, CityName = "Burgas" },
           new City() { Id = 5, CityName = "Ruse" },
           new City() { Id = 6, CityName = "Stara Zagora" },
           new City() { Id = 7, CityName = "Pleven" },
           new City() { Id = 8, CityName = "Sliven" },
           new City() { Id = 9, CityName = "Dobrich" },
           new City() { Id = 10, CityName = "Shumen" },
           new City() { Id = 11, CityName = "Pernik" },
           new City() { Id = 12, CityName = "Haskovo" },
           new City() { Id = 13, CityName = "Yambol" },
           new City() { Id = 14, CityName = "Pazardzhik" },
           new City() { Id = 15, CityName = "Blagoevgrad" },
           new City() { Id = 16, CityName = "Veliko Tarnovo" },
           new City() { Id = 17, CityName = "Vratsa" },
           new City() { Id = 18, CityName = "Gabrovo" },
           new City() { Id = 19, CityName = "Kardzhali" },
           new City() { Id = 20, CityName = "Kyustendil" },
           new City() { Id = 21, CityName = "Lovech" },
           new City() { Id = 22, CityName = "Montana" },
           new City() { Id = 23, CityName = "Razgrad" },
           new City() { Id = 24, CityName = "Silistra" },
           new City() { Id = 25, CityName = "Smolyan" },
           new City() { Id = 26, CityName = "Targovishte" },
           new City() { Id = 27, CityName = "Vidin" },
           new City() { Id = 28, CityName = "Sofia Province" }
};

        public void Configure(EntityTypeBuilder<City> entity)
        {
            entity.HasData(cities);
        }
    }
}
