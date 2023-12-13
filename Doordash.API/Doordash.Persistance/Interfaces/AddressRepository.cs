using Doordash.Data;
using Doordash.Data.Entities;
using Doordash.Data.Interfaces;
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
            _logger.LogInformation($"Creating address with id: {address.Id}");

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
    }
}
