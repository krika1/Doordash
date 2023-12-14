using Doordash.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Doordash.Data.Interfaces
{
    public interface IMenuItemRepository
    {
        Task<MenuItem> CreateMenuItem(MenuItem menuItem);

        Task<IEnumerable<MenuItem>> GetAllResturantMenuItems(Guid resturantId);
    }
}
