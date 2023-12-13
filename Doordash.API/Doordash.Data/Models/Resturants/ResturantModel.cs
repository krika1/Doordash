using Doordash.Data.Models.Addresses;
using System;

namespace Doordash.Data.Models.Resturants
{
    public class ResturantModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public string Type { get; set; }

        public AddressModel Address { get; set; }
    }
}
