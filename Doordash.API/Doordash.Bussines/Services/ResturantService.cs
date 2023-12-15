using Doordash.Data.Entities;
using Doordash.Data.Exceptions;
using Doordash.Data.Interfaces;
using Doordash.Data.Models.Addresses;
using Doordash.Data.Models.Resturants;
using Doordash.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Doordash.Bussines.Services
{
    public class ResturantService : IResturantService
    {
        private readonly IRestrurantRepository _resturantRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IMenuItemRepository _menuItemRepository;

        public ResturantService(IRestrurantRepository resturantRepository, IAddressRepository addressRepository, IMenuItemRepository menuItemRepository)
        {
            _resturantRepository = resturantRepository;
            _addressRepository = addressRepository;
            _menuItemRepository = menuItemRepository;
        }

        public async Task<ResturantModel> CreateResturantAsync(CreateResturantRequest request)
        {
            using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
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

        public async Task<IEnumerable<ResturantModel>> GetAllResturantsAsync(string town)
        {
            var resturants = await _resturantRepository.GetAllResturants(town);

            var resturantModels = resturants
                .Select(resturant => ResturantFactory
                .ToModel(resturant))
                .ToList();

            return resturantModels;
        }

        private async Task AttachAddressIdToResturant(Resturant resturant, Guid addressId)
        {
            resturant.AddressId = addressId;

            await _resturantRepository.UpdateResturant(resturant);
        }

        public async Task<ResturantModel> GetResturantByIdAsync(Guid resturantId)
        {
            var resturant = await GetResturantById(resturantId);

            var resturantModel = ResturantFactory.ToModel(resturant);

            return resturantModel;
        }

        public async Task DeleteResturantAsync(Guid resturantId)
        {
            var resturant = await GetResturantById(resturantId);
            resturant.DeletedOn = DateTime.Now;

            var resturantMenu = await _menuItemRepository.GetAllResturantMenuItems(resturantId);

            foreach (var menuItem in resturantMenu)
            {
                await _menuItemRepository.DeleteSingleMenuItem(menuItem.Id);
            }

            await _addressRepository.DeleteAddress(resturant.AddressId);
            await _resturantRepository.UpdateResturant(resturant);
        }

        private async Task<Resturant> GetResturantById(Guid resturantId)
        {
            var resturant = await _resturantRepository.GetSingleResturant(resturantId);

            if (resturant is null) throw new NotFoundException($"Resturant with id: {resturantId} not found.");

            return resturant;
        }
    }
}
