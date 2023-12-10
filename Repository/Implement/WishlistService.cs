using MoqaydaGP.Entities;
using MoqaydaGP.Repository.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoqaydaGP.Repository.Implement
{
    public class WishlistService : IWishlistService
    {
        private readonly IWishlistRepository wishlistRepository;

        public WishlistService(IWishlistRepository wishlistRepository)
        {
            this.wishlistRepository = wishlistRepository;
        }

        public Task<WishlistItem> CreateWishlistItemAsync(WishlistItem wishlistItem)
        {
            return wishlistRepository.CreateWishlistItemAsync(wishlistItem);
        }

        public Task<bool> DeleteWishlistItemAsync(long id)
        {
            return wishlistRepository.DeleteWishlistItemAsync(id);
        }

        public async Task<WishlistItem> GetUserAndWishlistItemsAsync(string userId)
        {
            return await wishlistRepository.GetUserAndWishlistItemsAsync(userId);
        }

        public Task<WishlistItem> GetWishlistItemAsync(string adObjName, int productId)
        {
            return wishlistRepository.GetWishlistItemAsync(adObjName, productId);
        }

        public Task<WishlistItem> GetWishlistItemAsync(long id)
        {
            return wishlistRepository.GetWishlistItemAsync(id);
        }

        public Task<List<WishlistItem>> GetWishlistItemsAsync()
        {
            return wishlistRepository.GetWishlistItemsAsync();
        }

        public Task<bool> IsWishlistItemExistAsync(long wishlistItemId)
        {
            return wishlistRepository.IsWishlistItemExistAsync(wishlistItemId);
        }

        public Task<bool> IsWishlistItemExistAsync(string ownerId, int productId)
        {
            return wishlistRepository.IsWishlistItemExistAsync(ownerId, productId);
        }
    }
}
