using System;

namespace Doordash.Data.Models.MenuItems
{
    public class MenuItemModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
