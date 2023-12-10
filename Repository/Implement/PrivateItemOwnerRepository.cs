using Microsoft.EntityFrameworkCore;
using MoqaydaGP.Data;
using MoqaydaGP.Entities;
using MoqaydaGP.Repository.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoqaydaGP.Repository.Implement
{
    public class PrivateItemOwnerRepository : IPrivateItemOwnerRepository
    {
        private readonly MoqaydaDbContext DbContext;
        public PrivateItemOwnerRepository(MoqaydaDbContext DbContext)
        {
            this.DbContext = DbContext;
        }
        public async Task<PrivateItemOwner> CreatePrivateItemOwnerAsync(PrivateItemOwner privateItemOwner)
        {
            DbContext.PrivateItemOwner.Add(privateItemOwner);
            await DbContext.SaveChangesAsync();
            return privateItemOwner;
        }

        public async Task<bool> DeletePrivateItemOwnerAsync(int id)
        {
            var entityToDelete = await DbContext.PrivateItemOwner.FindAsync(id);
            DbContext.PrivateItemOwner.Remove(entityToDelete);
            return await DbContext.SaveChangesAsync() > 0;
        }

        public Task<PrivateItemOwner> GetPrivateItemOwnerAsync(string adObjName, int privateItemId)
        {
            return DbContext.PrivateItemOwner.FirstOrDefaultAsync(f => f.PrivateItemId == privateItemId
       && f.UserId == adObjName);
        }

        public Task<PrivateItemOwner> GetPrivateItemOwnerAsync(int id)
        {
            return this.DbContext.PrivateItemOwner.FindAsync(id).AsTask();
        }

        public Task<List<PrivateItemOwner>> GetPrivateItemOwnersAsync()
        {
            return DbContext.PrivateItemOwner.ToListAsync();
        }

        public async Task<bool> IsPrivateItemOwnerExistAsync(int privateItemOwnerId)
        {
            var entity = await DbContext.PrivateItemOwner.FindAsync(privateItemOwnerId);
            return entity != null;
        }

        public async Task<bool> IsPrivateItemOwnerExistAsync(string ownerId, int privateItemId)
        {
            var wishlistItem = await DbContext.PrivateItemOwner.FirstOrDefaultAsync(f => f.PrivateItemId == privateItemId && f.UserId == ownerId);
            return wishlistItem != null;
        }
    }
}
