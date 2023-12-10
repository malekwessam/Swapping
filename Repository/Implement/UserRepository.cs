using Microsoft.EntityFrameworkCore;
using MoqaydaGP.Data;
using MoqaydaGP.Entities;
using MoqaydaGP.Repository.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoqaydaGP.Repository.Implement
{
    public class UserRepository : IUserRepository
    {
        private readonly MoqaydaDbContext DbContext;
        public UserRepository(MoqaydaDbContext DbContext)
        {
            this.DbContext = DbContext;
        }
        public async Task<User> CreateUserAsync(User user)
        {
            DbContext.User.Add(user);
            await DbContext.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUserAsync(string userId)
        {
            var userToRemove = await DbContext.User.FindAsync(userId);
            DbContext.User.Remove(userToRemove);
            return await DbContext.SaveChangesAsync() > 0;
        }

        public Task<User> GetUserAndBarteredPrivateItemsAsync(string userId)
        {
            return DbContext.User.AsNoTracking().Include(i => i.BarteredPriv).FirstOrDefaultAsync(f => f.Id == userId);
        }

        public Task<User> GetUserAndBarteredProductsAsync(string userId)
        {
            return DbContext.User.AsNoTracking().Include(i => i.BarteredProduct).FirstOrDefaultAsync(f => f.Id == userId);
        }

        public Task<User> GetUserAndPrivateItemOwnerAsync(string userId)
        {
            return DbContext.User.AsNoTracking().Include(i => i.PrivateItemOwner).FirstOrDefaultAsync(f => f.Id == userId);
        }

        public Task<User> GetUserAndPrivateItemsAsync(string userId)
        {
            return DbContext.User.AsNoTracking().Include(i => i.PrivateItem).FirstOrDefaultAsync(f => f.Id == userId);
        }

        public Task<User> GetUserAndPrivateOffersAsync(string userId)
        {
            return DbContext.User.AsNoTracking().Include(i => i.PrivToSwap).FirstOrDefaultAsync(f => f.Id == userId);
        }

        public Task<User> GetUserAndProdOffersAsync(string userId)
        {
            return DbContext.User.AsNoTracking().Include(i => i.ProdToSwap).FirstOrDefaultAsync(f => f.Id == userId);
        }

        public Task<User> GetUserAndProductOwnerAsync(string userId)
        {
            return DbContext.User.AsNoTracking().Include(i => i.ProductOwner).FirstOrDefaultAsync(f => f.Id == userId);
        }

        public Task<User> GetUserAndProductsAsync(string userId)
        {
            return DbContext.User.AsNoTracking().Include(i => i.Product).FirstOrDefaultAsync(f => f.Id == userId);
        }

        public Task<User> GetUserAndWishlistItemsAsync(string userId)
        {
            return DbContext.User.AsNoTracking().Include(i => i.WishlistItem).FirstOrDefaultAsync(f => f.Id == userId);
        }

        public Task<User> GetUserAsync(string name)
        {
            return this.DbContext.User.FirstOrDefaultAsync(f => f.firstName == name.ToLower());
        }

        public Task<User> GetuserAsync(string userId)
        {
            return this.DbContext.User.FindAsync(userId).AsTask();
        }

        public Task<List<User>> GetUsersAsync()
        {
            return this.DbContext.User.ToListAsync();
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            DbContext.User.Update(user);
            await DbContext.SaveChangesAsync();
            return user;
        }
    }
}
