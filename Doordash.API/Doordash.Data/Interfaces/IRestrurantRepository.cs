using Doordash.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Doordash.Data.Interfaces
{
    public interface IRestrurantRepository
    {
        Task<Resturant> CreateResturant(Resturant resturant);

        Task<IEnumerable<Resturant>> GetAllResturants();

        Task<Resturant> GetSingleResturant(Guid resturantId);

        Task UpdateResturant(Resturant resturant);
    }
}
