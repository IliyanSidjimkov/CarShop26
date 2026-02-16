using CarShop26.Data;
using CarShop26.Models;
using CarShop26.Services.Core.Interfaces;
using CarShop26.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarShop26.Services.Core
{
    public class CarService : ICarService
    {
        readonly CarShop26DbContext dbContext;
        public CarService(CarShop26DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddCarAsync(CarsFormModel addCarViewModel, string userId)
        {
            Car newCar = new Car()
            {
                Brand = addCarViewModel.Brand,
                Model = addCarViewModel.Model,
                Year = addCarViewModel.Year,
                Price = addCarViewModel.Price,
                Mileage = addCarViewModel.Mileage,
                FuelType = addCarViewModel.FuelType.Value,
                GearboxType = addCarViewModel.GearboxType.Value,
                ImageUrl = addCarViewModel.ImageUrl,
                CityId = addCarViewModel.CityId,
                CategoryId = addCarViewModel.CategoryId,
                UserId = userId
            };
            await dbContext.Cars.AddAsync(newCar);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> CarExistsaAsync(int id)
        {
            bool carExists  = await dbContext.Cars.AnyAsync(c => c.Id == id);
            return carExists;
        }

        public async Task DeleteCarAsync(int id,string userId)
        {
            Car? car = await dbContext.Cars.FirstOrDefaultAsync(c => c.Id == id);
            if (car == null)
            {
                throw new Exception();
            }

            if (car.UserId!.ToLowerInvariant() != userId.ToLowerInvariant())
            {
                throw new UnauthorizedAccessException();
            }
            dbContext.Cars.Remove(car);
            await dbContext.SaveChangesAsync();
        }

        public async Task EditCarAsync(int id, CarsFormModel editCarViewModel, string userId)
        {
            Car? carToEdit = await dbContext.Cars
             .FirstOrDefaultAsync(c => c.Id == id);
            if (carToEdit.UserId!.ToLowerInvariant() != userId.ToLowerInvariant())
            {
                throw new UnauthorizedAccessException();
            }

            carToEdit.Brand = editCarViewModel.Brand;
            carToEdit.Model = editCarViewModel.Model;
            carToEdit.Year = editCarViewModel.Year;
            carToEdit.Price = editCarViewModel.Price;
            carToEdit.Mileage = editCarViewModel.Mileage;
            carToEdit.FuelType = editCarViewModel.FuelType!.Value;
            carToEdit.GearboxType = editCarViewModel.GearboxType!.Value;
            carToEdit.ImageUrl = editCarViewModel.ImageUrl;
            carToEdit.CityId = editCarViewModel.CityId;
            carToEdit.CategoryId = editCarViewModel.CategoryId;
            carToEdit.CreatedOn = DateTime.UtcNow;

            dbContext.Cars.Update(carToEdit);
           await  dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllCarsViewModel>> GetAllCarsAsync(string? userId)
        {
            IEnumerable<AllCarsViewModel> allCars = await dbContext
               .Cars
               .AsNoTracking()
               .Include(c => c.User)
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
               .ToListAsync();

            return allCars;
        }

        public async  Task<CarsFormModel?> GetCarForEditAsync(int id, string userId)
        {
            Car? carToEdit = await dbContext
                    .Cars
                    .AsNoTracking()
                    .SingleOrDefaultAsync(c => c.Id == id);

            if (carToEdit == null)
            {
                return null;
            }

            if (carToEdit.UserId != userId)
            {
                throw new UnauthorizedAccessException();
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
                Cities = await dbContext.Cities.OrderBy(city => city.CityName).ToListAsync(),
                Categories = await dbContext.Categories.OrderBy(category => category.CategoryName).ToListAsync()
            };
            

            return editCarsFormModel;
        }

        public async Task<CarsFormModel> GetCarFormModelWhithCitiesAndCategoriesAsync()
        {
            CarsFormModel addCarsFormModel = new CarsFormModel()
            {
                Cities =await dbContext.Cities.OrderBy(city => city.CityName).ToListAsync(),
                Categories = await dbContext.Categories.OrderBy(category => category.CategoryName).ToListAsync()
            };
            return addCarsFormModel;

        }

        public async Task<DetailsViewModel?> GetDetailsAsync(int id, string returnUrl)
        {
            return await dbContext
                .Cars
            .AsNoTracking()
            .Where(c => c.Id == id)
            .Select(c => new DetailsViewModel
            {
                Id = c.Id,
                Brand = c.Brand,
                Model = c.Model,
                Year = c.Year,
                Price = (int)c.Price,
                Mileage = c.Mileage,
                ImageUrl = c.ImageUrl,
                FuelType = c.FuelType.ToString(),
                GearboxType = c.GearboxType.ToString(),
                City = c.City.CityName,
                Category = c.Category.CategoryName,
                OwnerName = c.User.UserName!,
                OwnerId = c.UserId!,
                CreatedOn = c.CreatedOn
            })
            .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<AllCarsViewModel>> GetMyCarsAsync(string? userId)
        {
            IEnumerable<AllCarsViewModel> myCars = await dbContext
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
                .ToListAsync();
            return myCars;
        }

        public async Task<bool> IsCategoryAndCityExistsAsync(int cityId, int categoryId)
        {
            bool cityExists = await dbContext.Cities.AnyAsync(c => c.Id == cityId);

           

            bool categoryExists = await dbContext.Categories.AnyAsync(c => c.Id == categoryId);
            return cityExists && categoryExists;
            
        }
    }
}
