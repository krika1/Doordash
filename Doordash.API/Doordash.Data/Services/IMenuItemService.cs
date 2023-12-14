using Doordash.Data.Models.MenuItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doordash.Data.Services
{
    public interface IMenuItemService
    {
        Task<MenuItemModel> CreateMenuItemAsync(Guid resturantId, CreateMenuItemRequest request);

        Task<IEnumerable<MenuItemModel>> GetAllResturantMenuItemsAsync(Guid resturantId);
    }
}
