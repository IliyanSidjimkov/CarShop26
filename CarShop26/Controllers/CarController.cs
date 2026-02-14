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
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

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
                    OwnerName = c.User.UserName!,
                    OwnerId = c.UserId!,
                    isFavourite = userId != null &&
                    dbContext.Favourites.Any(f => f.UserId == userId && f.CarId == c.Id)

                })
                .ToList();

            return View(allCars);
        }


        [HttpGet]
        [Authorize]
        public IActionResult AddCars(string returnUrl = null!)
        {

            CarsFormModel addCarsFormModel = new CarsFormModel()
            {
                Cities = dbContext.Cities.OrderBy(city => city.CityName).ToList(),
                Categories = dbContext.Categories.OrderBy(category => category.CategoryName).ToList()
            };
            ViewBag.ReturnUrl = returnUrl;

            return View(addCarsFormModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddCars(CarsFormModel addCarsFormModel, string returnUrl)
        {
            
            if (!ModelState.IsValid)
            {
                addCarsFormModel.Cities = dbContext.Cities.OrderBy(city => city.CityName).ToList();
                addCarsFormModel.Categories = dbContext.Categories.OrderBy(category => category.CategoryName).ToList();
                ViewBag.ReturnUrl = returnUrl;
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
            bool fuelTypeExists = Enum.IsDefined(addCarsFormModel.FuelType?.GetType()!, addCarsFormModel.FuelType);
            if (!fuelTypeExists)
            {
                ModelState.AddModelError(nameof(addCarsFormModel.FuelType), "Invalid fuel type!");
            }
            bool gearboxTypeExists = Enum.IsDefined(addCarsFormModel.GearboxType?.GetType()!, addCarsFormModel.GearboxType);
            if (!gearboxTypeExists)
            {
                ModelState.AddModelError(nameof(addCarsFormModel.GearboxType), "Invalid gearbox type!");
            }
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
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
                    UserId = userId
                };
                dbContext.Cars.Add(newCar);
                dbContext.SaveChanges();
                return Redirect(returnUrl ?? Url.Action(nameof(AllCars))!);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ModelState.AddModelError(string.Empty, "An error occurred while adding the car. Please try again.");
                return View(addCarsFormModel);
            }
        }
        [HttpGet]
        [Authorize]
        public IActionResult Details(int id, string returnUrl)
        {
            Car? carDetails = dbContext
                .Cars
                .Include(c => c.User)
                .Include(c => c.City)
                .Include(c => c.Category)
                .AsNoTracking()
                .SingleOrDefault(c => c.Id == id);

            if (carDetails == null)
            {
                return NotFound();
            }
            DetailsViewModel detailsViewModel = new DetailsViewModel()
            {
                Id = carDetails.Id,
                Brand = carDetails.Brand,
                Model = carDetails.Model,
                Year = carDetails.Year,
                Price = (int)carDetails.Price,
                Mileage = carDetails.Mileage,
                ImageUrl = carDetails.ImageUrl,
                FuelType = carDetails.FuelType.ToString(),
                GearboxType = carDetails.GearboxType.ToString(),
                City = carDetails.City.CityName,
                Category = carDetails.Category.CategoryName,
                OwnerName = carDetails.User.UserName!,
                OwnerId = carDetails.UserId!,
                CreatedOn = carDetails.CreatedOn
            };

            ViewBag.ReturnUrl = returnUrl;


            return View(detailsViewModel);
        }
        [HttpGet]
        [Authorize]
        public IActionResult Edit(int id, string returnUrl)
        {

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            Car? carToEdit = dbContext
                    .Cars
                    .AsNoTracking()
                    .SingleOrDefault(c => c.Id == id);
            if (carToEdit == null)
            {
                return NotFound();
            }

            if (carToEdit.UserId!.ToLowerInvariant() != userId.ToLowerInvariant())
            {
                return Unauthorized();
            }

            CarsFormModel editCarsFormModel = new CarsFormModel()
            {

                Brand = carToEdit.Brand,
                Model = carToEdit.Model,
                Year = carToEdit.Year,
                Price = carToEdit.Price,
                Mileage = carToEdit.Mileage,
                FuelType = carToEdit.FuelType,
                GearboxType = carToEdit.GearboxType,
                ImageUrl = carToEdit.ImageUrl,
                CityId = carToEdit.CityId,
                CategoryId = carToEdit.CategoryId,
                Cities = dbContext.Cities.OrderBy(city => city.CityName).ToList(),
                Categories = dbContext.Categories.OrderBy(category => category.CategoryName).ToList()
            };
            ViewBag.ReturnUrl = returnUrl;

            return View(editCarsFormModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(int id, CarsFormModel editCarsFormModel)
        {

            editCarsFormModel.Cities = dbContext.Cities.OrderBy(city => city.CityName).ToList();
            editCarsFormModel.Categories = dbContext.Categories.OrderBy(category => category.CategoryName).ToList();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            Car? carToEdit = dbContext
                    .Cars
                    .AsNoTracking()
                    .SingleOrDefault(c => c.Id == id);
            if (carToEdit == null)
            {
                return NotFound();
            }

            if (carToEdit.UserId!.ToLowerInvariant() != userId.ToLowerInvariant())
            {
                return Unauthorized();
            }
            if (!ModelState.IsValid)
            {
                return View(editCarsFormModel);
            }
            if (!ModelState.IsValid)
            {
                editCarsFormModel.Cities = dbContext.Cities.OrderBy(city => city.CityName).ToList();
                editCarsFormModel.Categories = dbContext.Categories.OrderBy(category => category.CategoryName).ToList();
                return View(editCarsFormModel);

            }
            bool cityExists = dbContext.Cities.Any(city => city.Id == editCarsFormModel.CityId);

            if (!cityExists)
            {
                ModelState.AddModelError(nameof(editCarsFormModel.CityId), "Invalid city!");
            }

            bool categoryExists = dbContext.Categories.Any(category => category.Id == editCarsFormModel.CategoryId);
            if (!categoryExists)
            {
                ModelState.AddModelError(nameof(editCarsFormModel.CategoryId), "Invalid category!");
            }
            bool fuelTypeExists = Enum.IsDefined(editCarsFormModel.FuelType?.GetType(), editCarsFormModel.FuelType);
            if (!fuelTypeExists)
            {
                ModelState.AddModelError(nameof(editCarsFormModel.FuelType), "Invalid fuel type!");
            }
            bool gearboxTypeExists = Enum.IsDefined(editCarsFormModel.GearboxType?.GetType()!, editCarsFormModel.GearboxType);
            if (!gearboxTypeExists)
            {
                ModelState.AddModelError(nameof(editCarsFormModel.GearboxType), "Invalid gearbox type!");
            }

            try
            {
                carToEdit.Brand = editCarsFormModel.Brand;
                carToEdit.Model = editCarsFormModel.Model;
                carToEdit.Year = editCarsFormModel.Year;
                carToEdit.Price = editCarsFormModel.Price;
                carToEdit.Mileage = editCarsFormModel.Mileage;
                carToEdit.FuelType = editCarsFormModel.FuelType.Value;
                carToEdit.GearboxType = editCarsFormModel.GearboxType.Value;
                carToEdit.ImageUrl = editCarsFormModel.ImageUrl;
                carToEdit.CityId = editCarsFormModel.CityId;
                carToEdit.CategoryId = editCarsFormModel.CategoryId;
                carToEdit.CreatedOn = DateTime.UtcNow;

                dbContext.Cars.Update(carToEdit);
                dbContext.SaveChanges();
                return RedirectToAction(nameof(Details), new { id });



            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ModelState.AddModelError(string.Empty, "An error occurred while adding the car. Please try again.");
                return View(editCarsFormModel);

            }



        }

        [HttpPost]
        [Authorize]
        public IActionResult Delete(int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            Car? car = dbContext.Cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            if (car.UserId!.ToLowerInvariant() != userId.ToLowerInvariant())
            {
                return Unauthorized();
            }
            dbContext.Cars.Remove(car);
            dbContext.SaveChanges();


            return RedirectToAction(nameof(AllCars));
        }

        [HttpGet]
        [Authorize]
        public IActionResult MyCars(int id)
        {

            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            IEnumerable<AllCarsViewModel> myCars = dbContext
                .Cars
                .Where(c => c.UserId == userId)
                .Select(c => new AllCarsViewModel()
                {
                    Id = c.Id,
                    Brand = c.Brand,
                    Model = c.Model,
                    ImageUrl = c.ImageUrl,
                    Price = c.Price,
                    OwnerName = c.User.UserName!,
                    OwnerId = c.UserId!
                    
                })
                .ToList();
            return View(myCars);
        }
    }

}



