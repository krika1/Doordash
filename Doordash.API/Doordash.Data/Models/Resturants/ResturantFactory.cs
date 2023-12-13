using Doordash.Data.Entities;
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

        public static ResturantModel ToModel(Resturant resturant)
        {
            return new ResturantModel
            {
               DeletedOn = resturant.DeletedOn,
               Description = resturant.Description,
               CreatedOn = resturant.CreatedOn,
               Id  = resturant.Id,
               Name = resturant.Name,
               Type = resturant.Type
            };
        }
    }
}
