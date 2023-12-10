using Microsoft.EntityFrameworkCore;
using MoqaydaGP.Data;
using MoqaydaGP.Entities;
using MoqaydaGP.Repository.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoqaydaGP.Repository.Implement
{
    public class BarteredProductRepository : IBarteredProductRepository
    {
        private readonly MoqaydaDbContext DbContext;
        public BarteredProductRepository(MoqaydaDbContext DbContext)
        {
            this.DbContext = DbContext;
        }
        public async Task<BarteredProduct> CreateBarteredProductAsync(BarteredProduct barteredProduct)
        {
            DbContext.BarteredProduct.Add(barteredProduct);
            await DbContext.SaveChangesAsync();
            return barteredProduct;
        }

        public async  Task<bool> DeleteBarteredProductAsync(int id)
        {
            var entityToDelete = await DbContext.BarteredProduct.FindAsync(id);
            DbContext.BarteredProduct.Remove(entityToDelete);
            return await DbContext.SaveChangesAsync() > 0;
        }

        public Task<BarteredProduct> GetBarteredProductAsync(string adObjName, int productId, int pObjectName)
        {
            return DbContext.BarteredProduct.FirstOrDefaultAsync(f => f.ProductId == productId
&& f.UserId == adObjName && f.ProductOwnerId == pObjectName);
        }

        public Task<BarteredProduct> GetBarteredProductAsync(int id)
        {
            return this.DbContext.BarteredProduct.FindAsync(id).AsTask();
        }

        public Task<List<BarteredProduct>> GetBarteredProductsAsync()
        {
            return DbContext.BarteredProduct.ToListAsync();
        }

        public Task<BarteredProduct> GetUserAndBarteredProductsAsync(string userId)
        {
            return DbContext.BarteredProduct.AsNoTracking().Include(i => i.User).FirstOrDefaultAsync(f => f.UserId == userId);
        }

        public async Task<bool> IsBarteredProductExistAsync(int barteredProductId)
        {
            var entity = await DbContext.BarteredProduct.FindAsync(barteredProductId);
            return entity != null;
        }

        public async Task<bool> IsBarteredProductExistAsync(string ownerId, int productId, int pOwnerId)
        {
            var wishlistItem = await DbContext.BarteredProduct.FirstOrDefaultAsync(f => f.ProductId == productId && f.UserId == ownerId && f.ProductOwnerId == pOwnerId);
            return wishlistItem != null;
        }
    }
}
