using MoqaydaGP.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoqaydaGP.Repository.Abstract
{
    public interface IPrivateItemOwnerRepository
    {
        Task<List<PrivateItemOwner>> GetPrivateItemOwnersAsync();
        Task<PrivateItemOwner> CreatePrivateItemOwnerAsync(PrivateItemOwner privateItemOwner);
        Task<bool> IsPrivateItemOwnerExistAsync(int privateItemOwnerId);
        Task<bool> DeletePrivateItemOwnerAsync(int id);
        Task<bool> IsPrivateItemOwnerExistAsync(string ownerId, int privateItemId);
        Task<PrivateItemOwner> GetPrivateItemOwnerAsync(string adObjName, int privateItemId);
        Task<PrivateItemOwner> GetPrivateItemOwnerAsync(int id);
       
    }
}
