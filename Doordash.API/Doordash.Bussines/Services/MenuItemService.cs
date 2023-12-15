using Doordash.Data.Entities;
using Doordash.Data.Exceptions;
using Doordash.Data.Interfaces;
using Doordash.Data.Models.MenuItems;
using Doordash.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task DeleteMenuItemAsync(Guid menuItemId)
        {
            await GetSingleMenuItem(menuItemId);

            await _menuItemRepository.DeleteSingleMenuItem(menuItemId);
        }

        public async Task<IEnumerable<MenuItemModel>> GetAllResturantMenuItemsAsync(Guid resturantId)
        {
            var menuItems = await _menuItemRepository.GetAllResturantMenuItems(resturantId);

            return menuItems.Select(menuItem => MenuItemFactory.ToModel(menuItem));
        }

        public async Task<MenuItemModel> GetSingleMenuItemAsync(Guid menuItemId)
        {
            var menuItem = await GetSingleMenuItem(menuItemId);

            return MenuItemFactory.ToModel(menuItem);
        }

        private async Task<MenuItem> GetSingleMenuItem(Guid menuItemId)
        {
            var menuItem = await _menuItemRepository.GetSingleMenuItem(menuItemId);

            if (menuItem is null) throw new NotFoundException($"Menu Item with id: {menuItemId} not found.");

            return menuItem;
        }
    }
}
