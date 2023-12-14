namespace Doordash.Data.Models.MenuItems
{
    public class CreateMenuItemRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
