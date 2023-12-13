using Doordash.Data.Models.Resturants;
using System.Threading.Tasks;

namespace Doordash.Data.Services
{
    public interface IResturantService
    {
        Task<ResturantModel> CreateResturantAsync(CreateResturantRequest request);
    }
}
