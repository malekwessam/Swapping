using MoqaydaGP.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoqaydaGP.Repository.Abstract
{
    public interface IPrivateItemService
    {
        PrivateItem GetPrivateItem(int privateItemId);


        Task<PrivateItem> GetPrivateItemAsync(int privateItemId);
        Task<List<PrivateItem>> GetPrivateItemsAsync();
        Task<PrivateItem> CreatePrivateItemAsync(PrivateItem privateItem);
        Task<PrivateItem> UpdatePrivateItemAsync(PrivateItem privateItem);
        Task<bool> DeletePrivateItemAsync(int privateItemId);
        Task<bool> IsPrivateItemNameExistAsync(string name);
        Task<bool> IsPrivateItemExistAsync(string name, int id);
        Task<PrivateItem> GetPrivateItemAndOwnerAsync(int privateItemId);
    }
}
