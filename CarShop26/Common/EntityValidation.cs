namespace CarShop26.Common
{
    public class EntityValidation
    {
        //Car Validation//
        public const int CarBrandMinLength = 3;
        public const int CarBrandMaxLength = 50;

        public const int CarModelMinLength = 2;
        public const int CarModelMaxLength = 50;

        public const int MinYear = 1950;
        public const int MaxYear = 2026;

        public const double MinPrice = 2000.00;
        public const double MaxPrice = 999999.99;

        public const int MinMileage = 100;
        public const int MaxMileage = 999999;


        //City Validation//
        public const int CityNameMinLength = 5;
        public const int CityNameMaxLength = 50;

        //category validation//
        public const int CategoryNameMinLength = 3;
        public const int CategoryNameMaxLength = 20;


    }
}
