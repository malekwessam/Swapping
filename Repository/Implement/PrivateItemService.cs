using MoqaydaGP.Entities;
using MoqaydaGP.Repository.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoqaydaGP.Repository.Implement
{
    public class PrivateItemService : IPrivateItemService
    {
        private readonly IPrivateItemRepository privateItemRepository;
        public PrivateItemService(IPrivateItemRepository privateItemRepository)
        {
            this.privateItemRepository = privateItemRepository;
        }
        public Task<PrivateItem> CreatePrivateItemAsync(PrivateItem privateItem)
        {
            return privateItemRepository.CreatePrivateItemAsync(privateItem);
        }

        public Task<bool> DeletePrivateItemAsync(int privateItemId)
        {
            return privateItemRepository.DeletePrivateItemAsync(privateItemId);
        }

        public PrivateItem GetPrivateItem(int privateItemId)
        {
            return privateItemRepository.GetPrivateItem(privateItemId);
        }

        public async Task<PrivateItem> GetPrivateItemAndOwnerAsync(int privateItemId)
        {
            return await privateItemRepository.GetPrivateItemAndOwnerAsync(privateItemId);
        }

        public Task<PrivateItem> GetPrivateItemAsync(int privateItemId)
        {
            return privateItemRepository.GetPrivateItemAsync(privateItemId);
        }

        public Task<List<PrivateItem>> GetPrivateItemsAsync()
        {
            return privateItemRepository.GetPrivateItemsAsync();
        }

        public async Task<bool> IsPrivateItemExistAsync(string name, int id)
        {
            var product = await privateItemRepository.GetPrivateItemByNameAsync(name, id);
            return product != null;
        }

        public async Task<bool> IsPrivateItemNameExistAsync(string name)
        {
            var product = await privateItemRepository.GetPrivateItemByNameAsync(name);
            return product != null;
        }

        public Task<PrivateItem> UpdatePrivateItemAsync(PrivateItem privateItem)
        {
            return privateItemRepository.UpdatePrivateItemAsync(privateItem);
        }
    }
}
