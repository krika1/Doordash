using Doordash.Data.Entities;
using Doordash.Data.Models.Addresses;
using System;

namespace Doordash.Data.Models.Resturants
{
    public static class ResturantFactory
    {
        public static Resturant ToDomain(CreateResturantRequest request)
        {
            return new Resturant
            {
                Description = request.Description,
                CreatedOn = DateTime.Now,
                Id = Guid.NewGuid(),
                Name = request.Name,
                Type = request.ResturantType
            };
        }

        public static Resturant ToDomain(ResturantModel model)
        {
            return new Resturant
            {
               AddressId = model.Address.AddressId,
               DeletedOn = model.DeletedOn,
               Description = model.Description,
               CreatedOn = model.CreatedOn,
               Id = model.Id,
               Name = model.Name,
               Type = model.Type
            };
        }

        public static ResturantModel ToModel(Resturant resturant)
        {
            return resturant is null ? null : new ResturantModel
            {
                Address = AddressFactory.ToModel(resturant.Address),
                DeletedOn = resturant.DeletedOn,
                Description = resturant.Description,
                CreatedOn = resturant.CreatedOn,
                Id = resturant.Id,
                Name = resturant.Name,
                Type = resturant.Type
            };
        }
    }
}
