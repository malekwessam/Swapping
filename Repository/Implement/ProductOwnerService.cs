using MoqaydaGP.Entities;
using MoqaydaGP.Repository.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoqaydaGP.Repository.Implement
{
    public class ProductOwnerService : IProductOwnerService
    {
        private readonly IProductOwnerRepository productOwnerRepository;

        public ProductOwnerService(IProductOwnerRepository productOwnerRepository)
        {
            this.productOwnerRepository = productOwnerRepository;
        }
        public Task<ProductOwner> CreateProductOwnerAsync(ProductOwner productOwner)
        {
            return productOwnerRepository.CreateProductOwnerAsync(productOwner);
        }

        public Task<bool> DeleteProductOwnerAsync(int id)
        {
            return productOwnerRepository.DeleteProductOwnerAsync(id);
        }

        public async Task<ProductOwner> GetProductOwnerAndPrivateOffersAsync(int id)
        {
            return await productOwnerRepository.GetProductOwnerAndPrivateOffersAsync(id);
        }

        public Task<ProductOwner> GetProductOwnerAsync(string adObjName, int productId)
        {
            return productOwnerRepository.GetProductOwnerAsync(adObjName, productId);
        }

        public Task<ProductOwner> GetProductOwnerAsync(int id)
        {
            return productOwnerRepository.GetProductOwnerAsync(id);
        }

        public Task<List<ProductOwner>> GetProductOwnersAsync()
        {
            return productOwnerRepository.GetProductOwnersAsync();
        }

        public Task<bool> IsProductOwnerExistAsync(int productOwnerId)
        {
            return productOwnerRepository.IsProductOwnerExistAsync(productOwnerId);
        }

        public Task<bool> IsProductOwnerExistAsync(string ownerId, int productId)
        {
            return productOwnerRepository.IsProductOwnerExistAsync(ownerId, productId);
        }
    }
}
