using System;

namespace Doordash.Data.Entities
{
    public class Resturant
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public string Type { get; set; }

        public Address Address { get; set; }

        public Guid AddressId { get; set; }
    }
}
