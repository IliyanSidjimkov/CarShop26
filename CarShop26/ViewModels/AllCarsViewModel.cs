namespace CarShop26.ViewModels
{

    // Controller shows to View (Without DataValidation)
    public class AllCarsViewModel
    {
        public int Id { get; set; }
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public decimal Price { get; set; }

        public string OwnerName { get; set; } = null!;

        public string OwnerId { get; set; } = null!;



    }
}
