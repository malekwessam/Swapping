using MoqaydaGP.Entities;
using MoqaydaGP.Repository.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoqaydaGP.Repository.Implement
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public Task<User> CreateUserAsync(User user)
        {
            return userRepository.CreateUserAsync(user);
        }

        public Task<bool> DeleteUserAsync(string userId)
        {
            return userRepository.DeleteUserAsync(userId);
        }

        public async Task<User> GetUserAndBarteredPrivateItemsAsync(string userId)
        {
            return await userRepository.GetUserAndBarteredPrivateItemsAsync(userId);
        }

        public async Task<User> GetUserAndBarteredProductsAsync(string userId)
        {
            return await userRepository.GetUserAndBarteredProductsAsync(userId);
        }

        public async Task<User> GetUserAndPrivateItemOwnerAsync(string userId)
        {
            return await userRepository.GetUserAndPrivateItemOwnerAsync(userId);
        }

        public async Task<User> GetUserAndPrivateItemsAsync(string userId)
        {
            return await userRepository.GetUserAndPrivateItemsAsync(userId);
        }

        public async Task<User> GetUserAndPrivateOffersAsync(string userId)
        {
            return await userRepository.GetUserAndPrivateOffersAsync(userId);
        }

        public async Task<User> GetUserAndProdOffersAsync(string userId)
        {
            return await userRepository.GetUserAndProdOffersAsync(userId);
        }

        public async Task<User> GetUserAndProductOwnerAsync(string userId)
        {
            return await userRepository.GetUserAndProductOwnerAsync(userId);
        }

        public async Task<User> GetUserAndProductsAsync(string userId)
        {
            return await userRepository.GetUserAndProductsAsync(userId);
        }

        public async Task<User> GetUserAndWishlistItemsAsync(string userId)
        {
            return await userRepository.GetUserAndWishlistItemsAsync(userId);
        }

        public Task<User> GetUserAsync(string userId)
        {
            return userRepository.GetUserAsync(userId);
        }

        public Task<List<User>> GetUsersAsync()
        {
            return userRepository.GetUsersAsync();
        }

        public async Task<bool> IsUserExistAsync(string name)
        {
            var user = await userRepository.GetUserAsync(name);
            return user != null;
        }

        public Task<User> UpdateUserAsync(User user)
        {
            return userRepository.UpdateUserAsync(user);
        }
    }
}
