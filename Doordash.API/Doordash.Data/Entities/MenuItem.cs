using System;

namespace Doordash.Data.Entities
{
    public class MenuItem
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public Resturant Resturant { get; set; }

        public Guid ResturantId { get; set; }
    }
}
