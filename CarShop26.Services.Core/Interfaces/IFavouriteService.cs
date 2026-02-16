using CarShop26.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop26.Services.Core.Interfaces
{
    public interface IFavouriteService
    {
        Task<IEnumerable<AllCarsViewModel>> GetAllFavouritesAsync(string userId);

        Task AddToFavouritesAsync(int carId, string userId);

        Task RemoveToFavouritesAsync(int carId, string userId);
    }
}
