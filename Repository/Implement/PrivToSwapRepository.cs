using Microsoft.EntityFrameworkCore;
using MoqaydaGP.Data;
using MoqaydaGP.Entities;
using MoqaydaGP.Repository.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoqaydaGP.Repository.Implement
{
    public class PrivToSwapRepository : IPrivToSwapRepository
    {
        private readonly MoqaydaDbContext DbContext;
        public PrivToSwapRepository(MoqaydaDbContext DbContext)
        {
            this.DbContext = DbContext;
        }
        public async Task<PrivToSwap> CreatePrivToSwapAsync(PrivToSwap privToSwap)
        {
            DbContext.PrivToSwap.Add(privToSwap);
            await DbContext.SaveChangesAsync();
            return privToSwap;
        }

        public async Task<bool> DeletePrivToSwapAsync(int id)
        {
            var entityToDelete = await DbContext.PrivToSwap.FindAsync(id);
            DbContext.PrivToSwap.Remove(entityToDelete);
            return await DbContext.SaveChangesAsync() > 0;
        }

        public Task<PrivToSwap> GetPrivToSwapAsync(string adObjName, int productId, int pObjectName)
        {
            return DbContext.PrivToSwap.FirstOrDefaultAsync(f => f.ProductId == productId
        && f.UserId == adObjName && f.PrivateItemOwnerId == pObjectName);
        }

        public Task<PrivToSwap> GetPrivToSwapAsync(int id)
        {
            return this.DbContext.PrivToSwap.FindAsync(id).AsTask();
        }

        public Task<List<PrivToSwap>> GetPrivToSwapsAsync()
        {
            return DbContext.PrivToSwap.ToListAsync();
        }

        public async Task<bool> IsPrivToSwapExistAsync(int privToSwapId)
        {
            var entity = await DbContext.PrivToSwap.FindAsync(privToSwapId);
            return entity != null;
        }

        public async Task<bool> IsPrivToSwapExistAsync(string ownerId, int productId, int pOwnerId)
        {
            var wishlistItem = await DbContext.PrivToSwap.FirstOrDefaultAsync(f => f.ProductId == productId && f.UserId == ownerId && f.PrivateItemOwnerId == pOwnerId);
            return wishlistItem != null;
        }
    }
}
