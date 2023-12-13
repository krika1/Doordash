using Doordash.Data.Entities;
using System.Threading.Tasks;

namespace Doordash.Data.Interfaces
{
    public interface IAddressRepository
    {
        Task<Address> CreateAddress(Address address);
    }
}
