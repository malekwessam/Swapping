using Microsoft.EntityFrameworkCore;
using MoqaydaGP.Data;
using MoqaydaGP.Entities;
using MoqaydaGP.Repository.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoqaydaGP.Repository.Implement
{
    public class ProdToSwapRepository : IProdToSwapRepository
    {
        private readonly MoqaydaDbContext DbContext;
        public ProdToSwapRepository(MoqaydaDbContext DbContext)
        {
            this.DbContext = DbContext;
        }
        public async Task<ProdToSwap> CreateProdToSwapAsync(ProdToSwap prodToSwap)
        {
            DbContext.ProdToSwap.Add(prodToSwap);
            await DbContext.SaveChangesAsync();
            return prodToSwap;
        }

        public async Task<bool> DeleteProdToSwapAsync(int id)
        {
            var entityToDelete = await DbContext.ProdToSwap.FindAsync(id);
            DbContext.ProdToSwap.Remove(entityToDelete);
            return await DbContext.SaveChangesAsync() > 0;
        }

        public Task<ProdToSwap> GetProdToSwapAsync(string adObjName, int productId, int pObjectName)
        {
            return DbContext.ProdToSwap.FirstOrDefaultAsync(f => f.ProductId == productId
          && f.UserId == adObjName && f.ProductOwnerId == pObjectName);
        }

        public Task<ProdToSwap> GetProdToSwapAsync(int id)
        {
            return this.DbContext.ProdToSwap.FindAsync(id).AsTask();
        }

        public Task<List<ProdToSwap>> GetProdToSwapsAsync()
        {
            return DbContext.ProdToSwap.ToListAsync();
        }

        public Task<ProdToSwap> GetUserAndProdOffersAsync(string userId)
        {
            return DbContext.ProdToSwap.AsNoTracking().Include(i => i.User).FirstOrDefaultAsync(f => f.UserId == userId);
        }

        public async Task<bool> IsProdToSwapExistAsync(int prodToSwapId)
        {
            var entity = await DbContext.ProdToSwap.FindAsync(prodToSwapId);
            return entity != null;
        }

        public async Task<bool> IsProdToSwapExistAsync(string ownerId, int productId, int pOwnerId)
        {
            var wishlistItem = await DbContext.ProdToSwap.FirstOrDefaultAsync(f => f.ProductId == productId && f.UserId == ownerId && f.ProductOwnerId == pOwnerId);
            return wishlistItem != null;
        }
    }
}
