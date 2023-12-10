using Microsoft.EntityFrameworkCore;
using MoqaydaGP.Data;
using MoqaydaGP.Entities;
using MoqaydaGP.Repository.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoqaydaGP.Repository.Implement
{
    public class WishlistRepository : IWishlistRepository
    {
        private readonly MoqaydaDbContext DbContext;
        public WishlistRepository(MoqaydaDbContext DbContext)
        {
            this.DbContext = DbContext;
        }
        public async Task<WishlistItem> CreateWishlistItemAsync(WishlistItem wishlistItem)
        {
            DbContext.WishlistItem.Add(wishlistItem);
            await DbContext.SaveChangesAsync();
            return wishlistItem;
        }

        public async Task<bool> DeleteWishlistItemAsync(long id)
        {
            var entityToDelete = await DbContext.WishlistItem.FindAsync(id);
            DbContext.WishlistItem.Remove(entityToDelete);
            return await DbContext.SaveChangesAsync() > 0;
        }

        public Task<WishlistItem> GetUserAndWishlistItemsAsync(string userId)
        {

            return DbContext.WishlistItem.AsNoTracking().Include(i => i.User).FirstOrDefaultAsync(f => f.UserId == userId);

        }

        public Task<WishlistItem> GetWishlistItemAsync(string adObjName, int productId)
        {
            return DbContext.WishlistItem.FirstOrDefaultAsync(f => f.ProductId == productId
           && f.UserId == adObjName);
        }

        public Task<WishlistItem> GetWishlistItemAsync(long id)
        {
            return this.DbContext.WishlistItem.FindAsync(id).AsTask();
        }

        public Task<List<WishlistItem>> GetWishlistItemsAsync()
        {
            return DbContext.WishlistItem.ToListAsync();
        }

        public async Task<bool> IsWishlistItemExistAsync(long wishlistItemId)
        {
            var entity = await DbContext.WishlistItem.FindAsync(wishlistItemId);
            return entity != null;
        }

        public async Task<bool> IsWishlistItemExistAsync(string ownerId, int productId)
        {
            var wishlistItem = await DbContext.WishlistItem.FirstOrDefaultAsync(f => f.ProductId == productId && f.UserId == ownerId);
            return wishlistItem != null;
        }
    }
}
