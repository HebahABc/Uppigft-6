using System.Diagnostics;
using WebApplication1.Helpers.Repositories;
using WebApplication1.Models.Entities;

namespace WebApplication1.Helpers.Services
{
    public class AddressServices
    {
        private readonly AddressRepo _addressRepo;
        private readonly UserAddressRepo _userAddressRepo;

        public AddressServices(AddressRepo addressRepo, UserAddressRepo userAddressRepo)
        {
            _addressRepo = addressRepo;
            _userAddressRepo = userAddressRepo;
        }

        public async Task<AddressEntity> GetOrCreateAsync(AddressEntity addressEntity)
        {
            var entity = await _addressRepo.GetAsync
                (
                    x => x.Address == addressEntity.Address &&
                    x.PostalCode == addressEntity.PostalCode &&
                    x.City == addressEntity.City
                );

            entity ??= await _addressRepo.AddAsync(addressEntity);
            return entity!;
        }

        public async Task<bool> AddUserAddressAsync(UserEntity user, AddressEntity address)
        {
            try
            {
                var entity = await _userAddressRepo.AddAsync(new UserAddressEntity
                {

                    UserId = user.Id,
                    AddressId = address.Id,

                });
                if (entity != null)
                {
                    return true;
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return false;
            
        }

    }
}
