using MoqaydaGP.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoqaydaGP.Repository.Abstract
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(string name);

        Task<User> GetuserAsync(string userId);
        Task<List<User>> GetUsersAsync();
        Task<User> CreateUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(string userId);
        Task<User> GetUserAndProductsAsync(string userId);
        Task<User> GetUserAndPrivateOffersAsync(string userId);
        Task<User> GetUserAndWishlistItemsAsync(string userId);
        Task<User> GetUserAndProdOffersAsync(string userId);
        Task<User> GetUserAndPrivateItemsAsync(string userId);
        Task<User> GetUserAndBarteredProductsAsync(string userId);
        Task<User> GetUserAndBarteredPrivateItemsAsync(string userId);
        Task<User> GetUserAndProductOwnerAsync(string userId);
        Task<User> GetUserAndPrivateItemOwnerAsync(string userId);
    }
}
