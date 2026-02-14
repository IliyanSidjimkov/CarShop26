using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CarShop26.Models
{
    public class Favourites
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = null!;
        public IdentityUser User { get; set; } = null!;

        [Required]
        public int CarId { get; set; }
        public Car Car { get; set; } = null!;


    }
}
