using Doordash.Data;
using Doordash.Data.Entities;
using Doordash.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doordash.Persistance.Interfaces
{
    public class ResturantRepository : IRestrurantRepository
    {
        private readonly ApplicationDbContext _database;
        private readonly ILogger<ResturantRepository> _logger;

        public ResturantRepository(ApplicationDbContext database, ILogger<ResturantRepository> logger)
        {
            _database = database;
            _logger = logger;
        }

        public async Task<Resturant> CreateResturant(Resturant resturant)
        {
            _logger.LogInformation($"Creating resturant with id: {resturant.Id}.");

            try
            {
                var entry = await _database.Resturants.AddAsync(resturant);

                await _database.SaveChangesAsync();

                return entry.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<Resturant>> GetAllResturants()
        {
            _logger.LogInformation($"Getting all resturants.");

            try
            {
                var resturants = await _database.Resturants.Where(resturant => resturant.DeletedOn == null).AsNoTracking().ToListAsync();

                return resturants;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<Resturant> GetSingleResturant(Guid resturantId)
        {
            _logger.LogInformation($"Getting resturant with id: {resturantId}.");

            try
            {
                var resturant = await _database.Resturants.AsNoTracking().FirstOrDefaultAsync(resturant => resturant.Id.Equals(resturantId));

                return resturant;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task UpdateResturant(Resturant resturant)
        {
            _logger.LogInformation($"Updating resturant with id: {resturant.Id}.");

            try
            {
                _database.Resturants.Update(resturant);

                await _database.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
