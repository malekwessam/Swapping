using Microsoft.EntityFrameworkCore;
using MoqaydaGP.Data;
using MoqaydaGP.Entities;
using MoqaydaGP.Repository.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoqaydaGP.Repository.Implement
{
    public class BarteredPrivRepository: IBarteredPrivRepository
    {
        private readonly MoqaydaDbContext DbContext;
        public BarteredPrivRepository(MoqaydaDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task<BarteredPriv> CreateBarteredPrivAsync(BarteredPriv barteredPriv)
        {
            DbContext.BarteredPriv.Add(barteredPriv);
            await DbContext.SaveChangesAsync();
            return barteredPriv;
        }

        public async  Task<bool> DeleteBarteredPrivAsync(int id)
        {
            var entityToDelete = await DbContext.BarteredPriv.FindAsync(id);
            DbContext.BarteredPriv.Remove(entityToDelete);
            return await DbContext.SaveChangesAsync() > 0;
        }

        public Task<BarteredPriv> GetBarteredPrivAsync(string adObjName, int productId, int pObjectName)
        {
            return DbContext.BarteredPriv.FirstOrDefaultAsync(f => f.ProductId == productId
&& f.UserId == adObjName && f.PrivateItemOwnerId == pObjectName);
        }

        public Task<BarteredPriv> GetBarteredPrivAsync(int id)
        {
            return this.DbContext.BarteredPriv.FindAsync(id).AsTask();
        }

        public Task<List<BarteredPriv>> GetBarteredPrivsAsync()
        {
            return DbContext.BarteredPriv.ToListAsync();
        }

        public async Task<bool> IsBarteredPrivExistAsync(int barteredPrivId)
        {
            var entity = await DbContext.BarteredPriv.FindAsync(barteredPrivId);
            return entity != null;
        }

        public async Task<bool> IsBarteredPrivExistAsync(string ownerId, int productId, int pOwnerId)
        {
            var wishlistItem = await DbContext.BarteredPriv.FirstOrDefaultAsync(f => f.ProductId == productId && f.UserId == ownerId && f.PrivateItemOwnerId == pOwnerId);
            return wishlistItem != null;
        }
    }
}
