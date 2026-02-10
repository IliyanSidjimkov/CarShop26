namespace CarShop26.ViewModels
{
    public class DetailsViewModel
    {
        public int Id { get; set; }

        public string Brand { get; set; } = null!;

        public string Model { get; set; } = null!;

        public int Year { get; set; }

        public int Price { get; set; }

        public int Mileage { get; set; }

        public string ImageUrl { get; set; } = null!;

        public string FuelType { get; set; } = null!;

        public string GearboxType { get; set; } = null!;

        public string City { get; set; } = null!;

        public string Category { get; set; } = null!;

        public string OwnerName { get; set; } = null!;

         public string OwnerId { get; set; } = null!;


    }
}
