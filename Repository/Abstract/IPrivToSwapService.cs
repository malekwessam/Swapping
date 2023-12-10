using MoqaydaGP.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoqaydaGP.Repository.Abstract
{
    public interface IPrivToSwapService
    {
        Task<List<PrivToSwap>> GetPrivToSwapsAsync();
        Task<PrivToSwap> CreatePrivToSwapAsync(PrivToSwap privToSwap);
        Task<bool> IsPrivToSwapExistAsync(int privToSwapId);
        Task<bool> DeletePrivToSwapAsync(int id);
        Task<bool> IsPrivToSwapExistAsync(string ownerId, int productId, int pOwnerId);
        Task<PrivToSwap> GetPrivToSwapAsync(string adObjName, int productId, int pObjectName);
        Task<PrivToSwap> GetPrivToSwapAsync(int id);
    }
}
