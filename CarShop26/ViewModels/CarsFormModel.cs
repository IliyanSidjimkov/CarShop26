using CarShop26.Models;
using System.ComponentModel.DataAnnotations;
// Form Model to Controller -> Data Validation/
namespace CarShop26.ViewModels
{
    using static Common.EntityValidation;
    public class CarsFormModel
    {
        [Required]
        [MaxLength(CarBrandMaxLength)]
        [MinLength(CarBrandMinLength)]
        public string Brand { get; set; } = null!;

        [Required]
        [MaxLength(CarModelMaxLength)]
        [MinLength(CarModelMinLength)]
        public string Model { get; set; } = null!;

        [Required]
        [Range(MinYear, MaxYear)]
        public int Year { get; set; }

        [Required]
        [Range(MinPrice, MaxPrice)]
        public decimal Price { get; set; }

        [Required]
        [Range(MinMileage, MaxMileage)]
        public int Mileage { get; set; }

        [Required]
        public FuelType? FuelType { get; set; }

        [Required]
        public GearboxType? GearboxType { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public int CityId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<City> Cities { get; set; } = new List<City>();

        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    }
}
