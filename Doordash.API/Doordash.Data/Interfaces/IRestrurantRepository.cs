﻿using Doordash.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Doordash.Data.Interfaces
{
    public interface IRestrurantRepository
    {
        Task<Resturant> CreateResturant(Resturant resturant);

        Task<IEnumerable<Resturant>> GetAllResturants();

        Task UpdateResturant(Resturant resturant);
    }
}
