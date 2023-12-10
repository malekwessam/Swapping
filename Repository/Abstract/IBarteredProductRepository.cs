using MoqaydaGP.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoqaydaGP.Repository.Abstract
{
    public interface IBarteredProductRepository
    {
        Task<List<BarteredProduct>> GetBarteredProductsAsync();
        Task<BarteredProduct> CreateBarteredProductAsync(BarteredProduct barteredProduct);
        Task<bool> IsBarteredProductExistAsync(int barteredProductId);
        Task<bool> DeleteBarteredProductAsync(int id);
        Task<bool> IsBarteredProductExistAsync(string ownerId, int productId, int pOwnerId);
        Task<BarteredProduct> GetBarteredProductAsync(string adObjName, int productId, int pObjectName);
        Task<BarteredProduct> GetBarteredProductAsync(int id);
        Task<BarteredProduct> GetUserAndBarteredProductsAsync(string userId);
    }
}
