using MoqaydaGP.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoqaydaGP.Repository.Abstract
{
    public interface IProductOwnerService
    {

        Task<List<ProductOwner>> GetProductOwnersAsync();
        Task<ProductOwner> CreateProductOwnerAsync(ProductOwner productOwner);
        Task<bool> IsProductOwnerExistAsync(int productOwnerId);
        Task<bool> IsProductOwnerExistAsync(string ownerId, int productId);
        Task<bool> DeleteProductOwnerAsync(int id);
        Task<ProductOwner> GetProductOwnerAsync(string adObjName, int productId);
        Task<ProductOwner> GetProductOwnerAsync(int id);
        Task<ProductOwner> GetProductOwnerAndPrivateOffersAsync(int id);
    }
}
