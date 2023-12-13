using System;

namespace Doordash.Data.Entities
{
    public class Address
    {
        public Guid Id { get; set; }

        public string Town { get; set; }

        public string Type { get; set; }

        public string AreaCode { get; set; }

        public string StreetAddress { get; set; }

        public string HouseNumber { get; set; }

        public Resturant Resturant { get; set; }

        public Guid ResturantId { get; set; }
    }
}
