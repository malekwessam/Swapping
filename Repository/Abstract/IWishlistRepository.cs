using MoqaydaGP.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoqaydaGP.Repository.Abstract
{
    public interface IWishlistRepository
    {
        Task<List<WishlistItem>> GetWishlistItemsAsync();
        Task<WishlistItem> CreateWishlistItemAsync(WishlistItem wishlistItem);
        Task<bool> IsWishlistItemExistAsync(long wishlistItemId);
        Task<bool> DeleteWishlistItemAsync(long id);
        Task<bool> IsWishlistItemExistAsync(string ownerId, int productId);
        Task<WishlistItem> GetWishlistItemAsync(string adObjName, int productId);
        Task<WishlistItem> GetWishlistItemAsync(long id);
        Task<WishlistItem> GetUserAndWishlistItemsAsync(string userId);
    }
}
