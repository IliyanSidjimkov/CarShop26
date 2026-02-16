
using CarShop26.Services.Core.Interfaces;
using CarShop26.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;

namespace CarShop26.Controllers
{
    public class FavouritesController : Controller
    {
       
        private readonly IFavouriteService favouriteService;
        public FavouritesController(IFavouriteService favouriteService)
        {
            
            this.favouriteService = favouriteService;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AllFavourites()
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            IEnumerable<AllCarsViewModel> favoriteCars = await favouriteService.GetAllFavouritesAsync(userId!);
            return View(favoriteCars);
        }

        [HttpPost]
        [Authorize]
        public async Task <IActionResult> AddToFavourites(int carId)
        {
            string? userId =  User.FindFirstValue(ClaimTypes.NameIdentifier);
            await favouriteService.AddToFavouritesAsync(carId, userId!);
            return RedirectToAction("AllCars", "Car");

        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> RemoveFromFavourites(int carId)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await favouriteService.RemoveToFavouritesAsync(carId, userId!);
            return RedirectToAction("AllFavourites", "Favourites");

        }
    }

}
