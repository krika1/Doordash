using Doordash.Data.Entities;
using Doordash.Data.Interfaces;
using Doordash.Data.Models.Addresses;
using Doordash.Data.Models.Resturants;
using Doordash.Data.Services;
using System;
using System.Threading.Tasks;
using System.Transactions;

namespace Doordash.Bussines.Services
{
    public class ResturantService : IResturantService
    {
        private readonly IRestrurantRepository _resturantRepository;
        private readonly IAddressRepository _addressRepository;

        public ResturantService(IRestrurantRepository resturantRepository, IAddressRepository addressRepository)
        {
            _resturantRepository = resturantRepository;
            _addressRepository = addressRepository;
        }

        public async Task<ResturantModel> CreateResturantAsync(CreateResturantRequest request)
        {
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var resturantDomain = ResturantFactory.ToDomain(request);

                    var createdResturant = await _resturantRepository.CreateResturant(resturantDomain).ConfigureAwait(false);

                    var addressDomain = AddressFactory.ToDomain(request, createdResturant.Id);

                    var createdAddress = await _addressRepository.CreateAddress(addressDomain).ConfigureAwait(false);

                    await AttachAddressIdToResturant(createdResturant, createdAddress.Id);

                    transaction.Complete();

                    var resturantModel = ResturantFactory.ToModel(createdResturant);
                    var addressModel = AddressFactory.ToModel(createdAddress);

                    resturantModel.Address = addressModel;

                    return resturantModel;
                }
                catch (Exception)
                {
                    transaction.Dispose();
                    throw;
                }
            }
        }


        private async Task AttachAddressIdToResturant(Resturant resturant, Guid addressId)
        {
            resturant.AddressId = addressId;

            await _resturantRepository.UpdateResturant(resturant);
        }
    }
}
