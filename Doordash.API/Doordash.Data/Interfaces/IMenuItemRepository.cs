using Doordash.Data.Entities;
using System.Threading.Tasks;

namespace Doordash.Data.Interfaces
{
    public interface IMenuItemRepository
    {
        Task<MenuItem> CreateMenuItem(MenuItem menuItem);
    }
}
