using CarShop26.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarShop26.Data.Configuration
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {

        private readonly Category[] categories = new Category[]
        {
            new Category()
            {
                Id = 1,
                CategoryName = "Van"
            },
            new Category()
            {
                Id = 2,
                CategoryName = "Jeep"
            },
            new Category()
            {
                Id = 3,
                CategoryName = "Cabriolet"
            },
            new Category()
            {
                Id = 4,
                CategoryName = "Avant"
            },
            new Category()
            {
                Id = 5,
                CategoryName = "Coupe"
            },
            new Category()
            {
                Id = 6,
                CategoryName = "Minivan"
            },
            new Category()
            {
                Id = 7,
                CategoryName = "Pickup Truck"
            },
            new Category()
            {
                Id = 8,
                CategoryName = "Sedan"
            },
            new Category()
            {
                Id = 9,
                CategoryName = "Hatchback"
            },
            new Category()
            {
                Id = 10,
                CategoryName = "SUV"
            },
            new Category()
            {
                Id = 11,
                CategoryName = "Sportback"
            }
        };
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.HasData(categories);
        }
    }
}
