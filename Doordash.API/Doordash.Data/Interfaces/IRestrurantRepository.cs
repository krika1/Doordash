using Doordash.Data.Entities;
using System.Threading.Tasks;

namespace Doordash.Data.Interfaces
{
    public interface IRestrurantRepository
    {
        Task<Resturant> CreateResturant(Resturant resturant);

        Task UpdateResturant(Resturant resturant);
    }
}
