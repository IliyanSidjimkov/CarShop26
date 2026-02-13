using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;



namespace CarShop26.Models
{
    using static Common.EntityValidation;
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(CarBrandMaxLength)]
        public string Brand { get; set; } = null!;

        [Required]
        [MaxLength(CarModelMaxLength)]
        public string Model { get; set; } = null!;

        [Required]        
        public int Year { get; set; }

        [Required]       
        public decimal Price { get; set; }

        [Required]       
        public int Mileage { get; set; }

        [Required]
        public FuelType FuelType { get; set; } 

        [Required]
        public GearboxType GearboxType { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; } = null!;

        public DateTime CreatedOn { get; set; } = DateTime.Now;


        //Connections//
        [Required]
        public string? UserId { get; set; }

        public virtual IdentityUser User { get; set; } = null!;

        [Required]
        public int CityId { get; set; }
        public virtual City City { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;





    }
}
