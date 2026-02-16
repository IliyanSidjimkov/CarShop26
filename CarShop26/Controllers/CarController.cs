using CarShop26.Data;
using CarShop26.Models;
using CarShop26.Services.Core.Interfaces;
using CarShop26.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CarShop26.Controllers
{
    public class CarController : Controller 
    {
       
        private readonly ICarService carService;
        public CarController( ICarService carService)
        {
            this.carService = carService;
           
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AllCars()
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            IEnumerable<AllCarsViewModel> allCars = await carService
                .GetAllCarsAsync(userId);

            return View(allCars);
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddCars(string returnUrl = null!)
        {

            CarsFormModel addCarsFormModel = await carService
                .GetCarFormModelWhithCitiesAndCategoriesAsync();

             
            ViewBag.ReturnUrl = returnUrl;

            return View(addCarsFormModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddCars(CarsFormModel addCarsFormModel)
        {

            if (!ModelState.IsValid)
            {
                addCarsFormModel = await carService.GetCarFormModelWhithCitiesAndCategoriesAsync();

                return View(addCarsFormModel);

            }
            bool citiAndCategoryExist = await carService.IsCategoryAndCityExistsAsync(addCarsFormModel.CityId, addCarsFormModel.CategoryId);
            if (!citiAndCategoryExist)
            {
                ModelState.AddModelError(string.Empty, "Invalid city or category.");
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
                string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
               await carService.AddCarAsync(addCarsFormModel, userId!);
                return Redirect(Url.Action(nameof(AllCars))!);
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
        public async Task<IActionResult> Details(int id, string returnUrl)
        {
            DetailsViewModel? detailsViewModel = await carService.GetDetailsAsync(id, returnUrl);

            if (detailsViewModel == null)
            {
                return NotFound();
            }
            

            ViewBag.ReturnUrl = returnUrl;


            return View(detailsViewModel);
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id, string returnUrl)
        {

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            CarsFormModel? carsFormModel = await carService.GetCarForEditAsync(id, userId);

            ViewBag.ReturnUrl = returnUrl;

            return View(carsFormModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(int id, CarsFormModel editCarsFormModel)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            bool carExists = await carService.CarExistsaAsync(id);

            if (!carExists)
            {
                return NotFound();
            }

            
            bool cityAndCategoryExist =
                await carService.IsCategoryAndCityExistsAsync(editCarsFormModel.CityId, editCarsFormModel.CategoryId);

            if (!cityAndCategoryExist)
            {
                ModelState.AddModelError(string.Empty, "Invalid city or category.");
            }

            
            if (!editCarsFormModel.FuelType.HasValue)
            {
                ModelState.AddModelError(nameof(editCarsFormModel.FuelType), "Fuel type is required.");
            }

            if (!editCarsFormModel.GearboxType.HasValue)
            {
                ModelState.AddModelError(nameof(editCarsFormModel.GearboxType), "Gearbox type is required.");
            }

            

            try
            {
                await carService.EditCarAsync(id, editCarsFormModel, userId);
                return RedirectToAction(nameof(Details), new { id });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ModelState.AddModelError(string.Empty, "An error occurred while editing the car. Please try again.");
                return View(editCarsFormModel);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task <IActionResult> Delete(int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
              await carService.DeleteCarAsync(id, userId);
            return RedirectToAction(nameof(AllCars));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> MyCars(int id)
        {

            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            IEnumerable<AllCarsViewModel> myCars = await carService.GetMyCarsAsync(userId);
            return View(myCars);
        }
    }

}



