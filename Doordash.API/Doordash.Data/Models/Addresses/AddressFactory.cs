using Doordash.Data.Entities;
using Doordash.Data.Models.Resturants;
using System;

namespace Doordash.Data.Models.Addresses
{
    public static class AddressFactory
    {
        public static Address ToDomain(CreateResturantRequest request, Guid resturantId)
        {
            return new Address
            {
                AreaCode = request.AreaCode,
                HouseNumber = request.HouseNumber,
                Id = Guid.NewGuid(),
                ResturantId = resturantId,
                StreetAddress = request.StreetAddress,
                Town = request.Town,
                Type = request.AddressType
            };
        }

        public static AddressModel ToModel(Address address)
        {
            return new AddressModel
            {
                AddressId = address.Id,
                AreaCode = address.AreaCode,
                StreetAddress = address.StreetAddress,
                HouseNumber = address.HouseNumber,
                Town = address.Town,
                Type = address.Type
            };
        }
    }
}
