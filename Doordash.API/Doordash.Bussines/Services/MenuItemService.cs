using Doordash.Data.Interfaces;
using Doordash.Data.Models.MenuItems;
using Doordash.Data.Services;
using System;
using System.Threading.Tasks;

namespace Doordash.Bussines.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public MenuItemService(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        public async Task<MenuItemModel> CreateMenuItemAsync(Guid resturantId, CreateMenuItemRequest request)
        {
            var menuItem = MenuItemFactory.ToDomain(request, resturantId);

            var createdMenuItem = await _menuItemRepository.CreateMenuItem(menuItem);

            return MenuItemFactory.ToModel(createdMenuItem);
        }
    }
}
