using CarShop26.Data;
using CarShop26.Models;
using CarShop26.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CarShop26.Controllers
{
    public class FavouritesController : Controller
    {
        private readonly CarShop26DbContext dbContext;
        public FavouritesController(CarShop26DbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        [Authorize]
        public IActionResult AllFavourites()
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<AllCarsViewModel> favoriteCars = dbContext.Favourites
                .Include(f => f.Car)
                .Include(f => f.User)
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
                .ToList();
            return View(favoriteCars);
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddToFavourites(int carId)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            bool alreadyFavorited = dbContext.Favourites.Any(f => f.CarId == carId && f.UserId == userId);
            if (!alreadyFavorited)
            {
                dbContext.Favourites.Add(new Favourites
                {
                    UserId = userId!,
                    CarId = carId

                });
                dbContext.SaveChanges();
            }
            return RedirectToAction("AllCars", "Car");

        }
        [HttpPost]
        [Authorize]
        public IActionResult RemoveFromFavourites(int carId)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Favourites? favourite = dbContext.Favourites.FirstOrDefault(f => f.CarId == carId && f.UserId == userId);
            if (favourite != null)
            {
                dbContext.Favourites.Remove(favourite);
                dbContext.SaveChanges();
            }
            return RedirectToAction("AllFavourites", "Favourites");

        }
    }

}
