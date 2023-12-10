using MoqaydaGP.Entities;
using MoqaydaGP.Repository.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoqaydaGP.Repository.Implement
{
    public class PrivateItemOwnerService : IPrivateItemOwnerService
    {
        private readonly IPrivateItemOwnerRepository privateItemOwnerRepository;

        public PrivateItemOwnerService(IPrivateItemOwnerRepository privateItemOwnerRepository)
        {
            this.privateItemOwnerRepository = privateItemOwnerRepository;
        }

        public Task<PrivateItemOwner> CreatePrivateItemOwnerAsync(PrivateItemOwner privateItemOwner)
        {
            return privateItemOwnerRepository.CreatePrivateItemOwnerAsync(privateItemOwner);
        }

        public Task<bool> DeletePrivateItemOwnerAsync(int id)
        {
            return privateItemOwnerRepository.DeletePrivateItemOwnerAsync(id);
        }

        public Task<PrivateItemOwner> GetPrivateItemOwnerAsync(string adObjName, int privateItemId)
        {
            return privateItemOwnerRepository.GetPrivateItemOwnerAsync(adObjName, privateItemId);
        }

        public Task<PrivateItemOwner> GetPrivateItemOwnerAsync(int id)
        {
            return privateItemOwnerRepository.GetPrivateItemOwnerAsync(id);
        }

        public Task<List<PrivateItemOwner>> GetPrivateItemOwnersAsync()
        {
            return privateItemOwnerRepository.GetPrivateItemOwnersAsync();
        }

        public Task<bool> IsPrivateItemOwnerExistAsync(int privateItemOwnerId)
        {
            return privateItemOwnerRepository.IsPrivateItemOwnerExistAsync(privateItemOwnerId);
        }

        public Task<bool> IsPrivateItemOwnerExistAsync(string ownerId, int privateItemId)
        {
            return privateItemOwnerRepository.IsPrivateItemOwnerExistAsync(ownerId, privateItemId);
        }
    }
}
