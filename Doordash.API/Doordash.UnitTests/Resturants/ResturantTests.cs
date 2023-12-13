using Doordash.Bussines.Services;
using Doordash.Data.Entities;
using Doordash.Data.Interfaces;
using Doordash.Data.Models.Addresses;
using Doordash.Data.Models.Resturants;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Doordash.UnitTests.Resturants
{
    public class ResturantTests
    {
        [Fact]
        public async Task CreateRestaurantAsync_ValidRequest_ReturnsValidModel()
        {
            // Arrange
            var request = new CreateResturantRequest
            {
            };

            var restaurantDomain = ResturantFactory.ToDomain(request);
            var addressDomain = AddressFactory.ToDomain(request, It.IsAny<Guid>());

            var createdRestaurant = new Resturant 
            {
                Id = Guid.NewGuid(), 
            };

            var createdAddress = new Address 
            {
                Id = Guid.NewGuid(),
            };

            var restaurantRepositoryMock = new Mock<IRestrurantRepository>();
            restaurantRepositoryMock.Setup(repo => repo.CreateResturant(It.IsAny<Resturant>()))
                                    .ReturnsAsync(createdRestaurant);

            var addressRepositoryMock = new Mock<IAddressRepository>();
            addressRepositoryMock.Setup(repo => repo.CreateAddress(It.IsAny<Address>()))
                                 .ReturnsAsync(createdAddress);

            var service = new ResturantService(restaurantRepositoryMock.Object, addressRepositoryMock.Object);

            // Act
            var result = await service.CreateResturantAsync(request);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(createdRestaurant.Id, result.Id);

            Assert.NotNull(result.Address);
            Assert.Equal(createdAddress.Id, result.Address.AddressId);
        }
    }
}
