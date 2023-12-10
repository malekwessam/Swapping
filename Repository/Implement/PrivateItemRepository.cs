using Microsoft.EntityFrameworkCore;
using MoqaydaGP.Data;
using MoqaydaGP.Entities;
using MoqaydaGP.Repository.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoqaydaGP.Repository.Implement
{
    public class PrivateItemRepository : IPrivateItemRepository
    {
        private readonly MoqaydaDbContext DbContext;
        public PrivateItemRepository(MoqaydaDbContext DbContext)
        {
            this.DbContext = DbContext;
        }
        public async Task<PrivateItem> CreatePrivateItemAsync(PrivateItem privateItem)
        {
            DbContext.PrivateItem.Add(privateItem);
            await DbContext.SaveChangesAsync();
            return privateItem;
        }

        public async Task<bool> DeletePrivateItemAsync(int privateItemId)
        {
            var privateItemToRemove = await DbContext.PrivateItem.FindAsync(privateItemId);
            DbContext.Remove(privateItemToRemove);

            return await DbContext.SaveChangesAsync() > 0;
        }

        public PrivateItem GetPrivateItem(int privateItemId)
        {
            return this.DbContext.PrivateItem.Find(privateItemId);
        }

        public Task<PrivateItem> GetPrivateItemAndOwnerAsync(int privateItemId)
        {
            return DbContext.PrivateItem.AsNoTracking().Include(i => i.PrivateItemOwner).FirstOrDefaultAsync(f => f.Id == privateItemId);
        }

        public Task<PrivateItem> GetPrivateItemAsync(int privateItemId)
        {
            return this.DbContext.PrivateItem.FindAsync(privateItemId).AsTask();
        }

        public Task<PrivateItem> GetPrivateItemByNameAsync(string name)
        {
            return this.DbContext.PrivateItem.FirstOrDefaultAsync(f => f.PrivateItemeName.ToLower() == name.ToLower());
        }

        public Task<PrivateItem> GetPrivateItemByNameAsync(string name, int id)
        {
            return DbContext.PrivateItem.AsNoTracking().FirstOrDefaultAsync(f => f.PrivateItemeName.ToLower() == name.ToLower() && f.Id != id);
        }

        public Task<List<PrivateItem>> GetPrivateItemsAsync()
        {
            return this.DbContext.PrivateItem.ToListAsync();
        }

        public async Task<PrivateItem> UpdatePrivateItemAsync(PrivateItem privateItem)
        {
            DbContext.PrivateItem.Update(privateItem);
            await DbContext.SaveChangesAsync();
            return privateItem;
        }
    }
}
