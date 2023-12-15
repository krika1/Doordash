using Doordash.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Doordash.Data.Interfaces
{
    public interface IMenuItemRepository
    {
        Task<MenuItem> CreateMenuItem(MenuItem menuItem);

        Task<MenuItem> GetSingleMenuItem(Guid menuItemId);

        Task DeleteSingleMenuItem(Guid menuItemId);

        Task<IEnumerable<MenuItem>> GetAllResturantMenuItems(Guid resturantId);
    }
}
