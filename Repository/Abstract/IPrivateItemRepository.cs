using MoqaydaGP.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoqaydaGP.Repository.Abstract
{
    public interface IPrivateItemRepository
    {
        PrivateItem GetPrivateItem(int privateItemId);


        Task<PrivateItem> GetPrivateItemAsync(int privateItemId);
        Task<List<PrivateItem>> GetPrivateItemsAsync();

        Task<PrivateItem> CreatePrivateItemAsync(PrivateItem privateItem);
        Task<PrivateItem> UpdatePrivateItemAsync(PrivateItem privateItem);
        Task<bool> DeletePrivateItemAsync(int privateItemId);
        Task<PrivateItem> GetPrivateItemByNameAsync(string name);
        Task<PrivateItem> GetPrivateItemByNameAsync(string name, int id);
        Task<PrivateItem> GetPrivateItemAndOwnerAsync(int privateItemId);
    }
}
