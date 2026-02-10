using System.ComponentModel.DataAnnotations;

namespace CarShop26.Models
{
    using static Common.EntityValidation;
    public class City
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(CityNameMaxLength)]
        public string CityName { get; set; } = null!;

        public ICollection<Car> Cars { get; set; } = new HashSet<Car>();

    }
}
