using Doordash.Data;
using Doordash.Data.Entities;
using Doordash.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Doordash.Persistance.Interfaces
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _database;
        private readonly ILogger<AddressRepository> _logger;

        public AddressRepository(ApplicationDbContext database, ILogger<AddressRepository> logger)
        {
            _database = database;
            _logger = logger;
        }
        public async Task<Address> CreateAddress(Address address)
        {
            _logger.LogInformation($"Creating address with id: {address.Id}.");

            try
            {
                var entry = await _database.Addresses.AddAsync(address);

                await _database.SaveChangesAsync();

                return entry.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task DeleteAddress(Guid addressId)
        {
            _logger.LogInformation($"Deleting address with address Id: {addressId}.");

            try
            {
                var address = await _database.Addresses.FirstOrDefaultAsync(address => address.Id.Equals(addressId));

                _database.Addresses.Remove(address);

                await _database.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<Address> GetAddressByResturantId(Guid resturantId)
        {
            _logger.LogInformation($"Getting address with for resturant with resturant Id: {resturantId}.");

            try
            {
                var address = await _database.Addresses.FirstOrDefaultAsync(address => address.ResturantId.Equals(resturantId));

                return address;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
