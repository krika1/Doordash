using Doordash.Data;
using Doordash.Data.Entities;
using Doordash.Data.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Doordash.Persistance.Interfaces
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly ApplicationDbContext _database;
        private readonly ILogger<MenuItemRepository> _logger;

        public MenuItemRepository(ApplicationDbContext database, ILogger<MenuItemRepository> logger)
        {
            _database = database;
            _logger = logger;
        }
        public async Task<MenuItem> CreateMenuItem(MenuItem menuItem)
        {
            _logger.LogInformation($"Creating menu item with id: {menuItem.Id}.");

            try
            {
                var entry = await _database.MenuItems.AddAsync(menuItem);

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
