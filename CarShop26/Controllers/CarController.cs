using CarShop26.Data;
using CarShop26.Models;
using CarShop26.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CarShop26.Controllers
{
    public class CarController : Controller
    {
        private readonly CarShop26DbContext dbContext;
        public CarController(CarShop26DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Authorize]
        public IActionResult AllCars()
        {
            IEnumerable<AllCarsViewModel> allCars = dbContext
                .Cars
                .AsNoTracking()
                .OrderBy(c => c.Brand)
                .ThenBy(c => c.Model)
                .Select(c => new AllCarsViewModel()
                {
                    Id = c.Id,
                    Brand = c.Brand,
                    Model = c.Model,
                    ImageUrl = c.ImageUrl,
                    Price = c.Price,
                    OwnerName = c.User.UserName,
                    OwnerId = c.UserId
                })
                .ToList();

            return View(allCars);
        }


        [HttpGet]
        [Authorize]
        public IActionResult AddCars()
        {

            AddCarsFormModel addCarsFormModel = new AddCarsFormModel()
            {
                Cities = dbContext.Cities.OrderBy(city => city.CityName).ToList(),
                Categories = dbContext.Categories.OrderBy(category => category.CategoryName).ToList()
            };
            

            return View(addCarsFormModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddCars(AddCarsFormModel addCarsFormModel)
        {
            if (!ModelState.IsValid) 
            {
                addCarsFormModel.Cities = dbContext.Cities.OrderBy(city => city.CityName).ToList();
                addCarsFormModel.Categories = dbContext.Categories.OrderBy(category => category.CategoryName).ToList();
                return View(addCarsFormModel);

            }
            bool cityExists = dbContext.Cities.Any(city => city.Id == addCarsFormModel.CityId);

            if (!cityExists)
            {
                ModelState.AddModelError(nameof(addCarsFormModel.CityId), "Invalid city!");
            }

            bool categoryExists = dbContext.Categories.Any(category => category.Id == addCarsFormModel.CategoryId);
            if (!categoryExists)
            { 
                ModelState.AddModelError(nameof(addCarsFormModel.CategoryId), "Invalid category!");
            }
            bool fuelTypeExists = Enum.IsDefined(addCarsFormModel.FuelType?.GetType(), addCarsFormModel.FuelType);
            if (!fuelTypeExists)
            {
                ModelState.AddModelError(nameof(addCarsFormModel.FuelType), "Invalid fuel type!");
            }
            bool gearboxTypeExists = Enum.IsDefined(addCarsFormModel.GearboxType?.GetType(), addCarsFormModel.GearboxType);
            if (!gearboxTypeExists)
            {
                ModelState.AddModelError(nameof(addCarsFormModel.GearboxType), "Invalid gearbox type!");
            }

            try
            {
                Car newCar = new Car()
                {
                    Brand = addCarsFormModel.Brand,
                    Model = addCarsFormModel.Model,
                    Year = addCarsFormModel.Year,
                    Price = addCarsFormModel.Price,
                    Mileage = addCarsFormModel.Mileage,
                    FuelType = addCarsFormModel.FuelType.Value,
                    GearboxType = addCarsFormModel.GearboxType.Value,
                    ImageUrl = addCarsFormModel.ImageUrl,
                    CityId = addCarsFormModel.CityId,
                    CategoryId = addCarsFormModel.CategoryId,
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)!
                };
                dbContext.Cars.Add(newCar);
                dbContext.SaveChanges();
                return RedirectToAction(nameof(AllCars));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ModelState.AddModelError(string.Empty, "An error occurred while adding the car. Please try again.");
                return View(addCarsFormModel);
            } 
        }



       
    }
}
