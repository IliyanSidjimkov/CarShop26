using CarShop26.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop26.Services.Core.Interfaces
{
    public interface ICarService
    {

        Task<IEnumerable<AllCarsViewModel>> GetAllCarsAsync(string? userId);
        
        Task<CarsFormModel> GetCarFormModelWhithCitiesAndCategoriesAsync();

        Task AddCarAsync(CarsFormModel addCarViewModel, string userId);

        Task<DetailsViewModel?> GetDetailsAsync(int id, string returnUrl);

        Task<CarsFormModel?> GetCarForEditAsync(int id, string userId);

        Task<bool> CarExistsaAsync(int id);

        Task EditCarAsync(int id, CarsFormModel editCarViewModel, string userId);

        Task DeleteCarAsync(int id,string userId);

        Task<IEnumerable<AllCarsViewModel>> GetMyCarsAsync(string? userId);

    }
}
