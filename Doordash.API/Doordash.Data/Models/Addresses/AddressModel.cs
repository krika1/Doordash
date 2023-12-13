using System;

namespace Doordash.Data.Models.Addresses
{
    public class AddressModel
    {
        public Guid AddressId { get; set; }

        public string Town { get; set; }

        public string Type { get; set; }

        public string AreaCode { get; set; }

        public string StreetAddress { get; set; }

        public string HouseNumber { get; set; }
    }
}
