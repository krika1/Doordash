using Doordash.Data.Models.Resturants;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Doordash.Data.Services
{
    public interface IResturantService
    {
        Task<ResturantModel> CreateResturantAsync(CreateResturantRequest request);

        Task<IEnumerable<ResturantModel>> GetAllResturantsAsync(string town);

        Task DeleteResturantAsync(ResturantModel model);

        Task<ResturantModel> GetResturantByIdAsync(Guid resturantId);
    }
}
