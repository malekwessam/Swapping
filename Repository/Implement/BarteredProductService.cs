using MoqaydaGP.Entities;
using MoqaydaGP.Repository.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoqaydaGP.Repository.Implement
{
    public class BarteredProductService : IBarteredProductService
    {
        private readonly IBarteredProductRepository barteredProductRepository;

        public BarteredProductService(IBarteredProductRepository barteredProductRepository)
        {
            this.barteredProductRepository = barteredProductRepository;
        }
        public Task<BarteredProduct> CreateBarteredProductAsync(BarteredProduct barteredProduct)
        {
            return barteredProductRepository.CreateBarteredProductAsync(barteredProduct);
        }

        public Task<bool> DeleteBarteredProductAsync(int id)
        {
            return barteredProductRepository.DeleteBarteredProductAsync(id);
        }

        public Task<BarteredProduct> GetBarteredProductAsync(string adObjName, int productId, int pObjectName)
        {
            return barteredProductRepository.GetBarteredProductAsync(adObjName, productId, pObjectName);
        }

        public Task<BarteredProduct> GetBarteredProductAsync(int id)
        {
            return barteredProductRepository.GetBarteredProductAsync(id);
        }

        public Task<List<BarteredProduct>> GetBarteredProductsAsync()
        {
            return barteredProductRepository.GetBarteredProductsAsync();
        }

        public async Task<BarteredProduct> GetUserAndBarteredProductsAsync(string userId)
        {
            return await barteredProductRepository.GetUserAndBarteredProductsAsync(userId);
        }

        public Task<bool> IsBarteredProductExistAsync(int barteredProductId)
        {
            return barteredProductRepository.IsBarteredProductExistAsync(barteredProductId);
        }

        public Task<bool> IsBarteredProductExistAsync(string ownerId, int productId, int pOwnerId)
        {
            return barteredProductRepository.IsBarteredProductExistAsync(ownerId, productId, pOwnerId);
        }
    }
}
