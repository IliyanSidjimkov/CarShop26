using CarShop26.Data;
using CarShop26.Models;
using CarShop26.Services.Core.Interfaces;
using CarShop26.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop26.Services.Core
{
    public class FavouriteService : IFavouriteService
    {
        readonly CarShop26DbContext dbContext;
        public FavouriteService(CarShop26DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddToFavouritesAsync(int carId, string userId)
        {
            bool alreadyFavorited = await dbContext.Favourites.AnyAsync(f => f.CarId == carId && f.UserId == userId);
            if (!alreadyFavorited)
            {
                dbContext.Favourites.Add(new Favourites
                {
                    UserId = userId!,
                    CarId = carId

                });
                dbContext.SaveChanges();
            }
        }

        public async Task<IEnumerable<AllCarsViewModel>> GetAllFavouritesAsync(string userId)
        {
            List<AllCarsViewModel> favoriteCars = await dbContext.Favourites
                 .Where(f => f.UserId == userId)
                 .Select(f => new AllCarsViewModel
                 {
                     Id = f.Car.Id,
                     Brand = f.Car.Brand,
                     Model = f.Car.Model,
                     ImageUrl = f.Car.ImageUrl,
                     Price = f.Car.Price,
                     OwnerName = f.Car.User.UserName!,
                     OwnerId = f.Car.UserId
                 })
                 .ToListAsync();
            return favoriteCars;
        }

        public async Task RemoveToFavouritesAsync(int carId, string userId)
        {
            Favourites? favourite = await dbContext.Favourites.FirstOrDefaultAsync(f => f.CarId == carId && f.UserId == userId);
            if (favourite != null)
            {
                dbContext.Favourites.Remove(favourite);
                dbContext.SaveChanges();
            }
        }
    }
}
