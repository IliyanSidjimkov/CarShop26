using System.ComponentModel.DataAnnotations;

namespace CarShop26.Models
{
    using static Common.EntityValidation;
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(CategoryNameMaxLength)]
        public string CategoryName { get; set; } = null!;

        public ICollection<Car> Cars { get; set; } = new HashSet<Car>();
    }
}
