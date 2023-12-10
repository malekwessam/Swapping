using Microsoft.EntityFrameworkCore;
using MoqaydaGP.Data;
using MoqaydaGP.Entities;
using MoqaydaGP.Repository.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoqaydaGP.Repository.Implement
{
    public class ProductOwnerRepository : IProductOwnerRepository
    {
        private readonly MoqaydaDbContext DbContext;
        public ProductOwnerRepository(MoqaydaDbContext DbContext)
        {
            this.DbContext = DbContext;
        }
        public async Task<ProductOwner> CreateProductOwnerAsync(ProductOwner productOwner)
        {
            DbContext.ProductOwner.Add(productOwner);
            await DbContext.SaveChangesAsync();
            return productOwner;
        }

        public async Task<bool> DeleteProductOwnerAsync(int id)
        {
            var entityToDelete = await DbContext.ProductOwner.FindAsync(id);
            DbContext.ProductOwner.Remove(entityToDelete);
            return await DbContext.SaveChangesAsync() > 0;
        }

        public Task<ProductOwner> GetProductOwnerAndPrivateOffersAsync(int id)
        {
            return DbContext.ProductOwner.AsNoTracking().Include(i => i.PrivateSwap).FirstOrDefaultAsync(f => f.Id == id);
        }

        public Task<ProductOwner> GetProductOwnerAsync(string adObjName, int productId)
        {
            return DbContext.ProductOwner.FirstOrDefaultAsync(f => f.ProductId == productId
         && f.UserId == adObjName);
        }

        public Task<ProductOwner> GetProductOwnerAsync(int id)
        {
            return this.DbContext.ProductOwner.FindAsync(id).AsTask();
        }

        public Task<List<ProductOwner>> GetProductOwnersAsync()
        {
            return DbContext.ProductOwner.ToListAsync();
        }

        public async Task<bool> IsProductOwnerExistAsync(int productOwnerId)
        {
            var entity = await DbContext.ProductOwner.FindAsync(productOwnerId);
            return entity != null;
        }

        public async Task<bool> IsProductOwnerExistAsync(string ownerId, int productId)
        {
            var wishlistItem = await DbContext.ProductOwner.FirstOrDefaultAsync(f => f.ProductId == productId && f.UserId == ownerId);
            return wishlistItem != null;
        }
    }
}
