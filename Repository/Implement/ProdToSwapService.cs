using MoqaydaGP.Entities;
using MoqaydaGP.Repository.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoqaydaGP.Repository.Implement
{
    public class ProdToSwapService : IProdToSwapService
    {
        private readonly IProdToSwapRepository prodToSwapRepository;

        public ProdToSwapService(IProdToSwapRepository prodToSwapRepository)
        {
            this.prodToSwapRepository = prodToSwapRepository;
        }
        public Task<ProdToSwap> CreateProdToSwapAsync(ProdToSwap prodToSwap)
        {
            return prodToSwapRepository.CreateProdToSwapAsync(prodToSwap);
        }

        public Task<bool> DeleteProdToSwapAsync(int id)
        {
            return prodToSwapRepository.DeleteProdToSwapAsync(id);
        }

        public Task<ProdToSwap> GetProdToSwapAsync(string adObjName, int productId, int pObjectName)
        {
            return prodToSwapRepository.GetProdToSwapAsync(adObjName, productId, pObjectName);
        }

        public Task<ProdToSwap> GetProdToSwapAsync(int id)
        {
            return prodToSwapRepository.GetProdToSwapAsync(id);
        }

        public Task<List<ProdToSwap>> GetProdToSwapsAsync()
        {
            return prodToSwapRepository.GetProdToSwapsAsync();
        }

        public async Task<ProdToSwap> GetUserAndProdOffersAsync(string userId)
        {
            return await prodToSwapRepository.GetUserAndProdOffersAsync(userId);
        }

        public Task<bool> IsProdToSwapExistAsync(int prodToSwapId)
        {
            return prodToSwapRepository.IsProdToSwapExistAsync(prodToSwapId);
        }

        public Task<bool> IsProdToSwapExistAsync(string ownerId, int productId, int pOwnerId)
        {
            return prodToSwapRepository.IsProdToSwapExistAsync(ownerId, productId, pOwnerId);
        }
    }
}
