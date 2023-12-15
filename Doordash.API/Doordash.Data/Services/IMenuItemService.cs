using Doordash.Data.Models.MenuItems;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Doordash.Data.Services
{
    public interface IMenuItemService
    {
        Task<MenuItemModel> CreateMenuItemAsync(Guid resturantId, CreateMenuItemRequest request);

        Task<IEnumerable<MenuItemModel>> GetAllResturantMenuItemsAsync(Guid resturantId);

        Task<MenuItemModel> GetSingleMenuItemAsync(Guid menuItemId);

        Task DeleteMenuItemAsync(Guid menuItemId);
    }
}
