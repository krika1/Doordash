using Doordash.Data.Entities;
using System;

namespace Doordash.Data.Models.MenuItems
{
    public static class MenuItemFactory
    {
        public static MenuItem ToDomain(CreateMenuItemRequest request, Guid resturantId)
        {
            return new MenuItem
            {
                Description = request.Description,
                Id = Guid.NewGuid(),
                ResturantId = resturantId,
                Name = request.Name,    
                Price = request.Price,
            };
        }

        public static MenuItemModel ToModel(MenuItem menuItem)
        {
            return new MenuItemModel
            {
               Id = menuItem.Id,
               Name = menuItem.Name,
               Price = menuItem.Price,
               Description = menuItem.Description,
            };
        }
    }
}
