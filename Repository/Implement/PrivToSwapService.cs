using MoqaydaGP.Entities;
using MoqaydaGP.Repository.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoqaydaGP.Repository.Implement
{
    public class PrivToSwapService : IPrivToSwapService
    {
        private readonly IPrivToSwapRepository privToSwapRepository;

        public PrivToSwapService(IPrivToSwapRepository privToSwapRepository)
        {
            this.privToSwapRepository = privToSwapRepository;
        }
        public Task<PrivToSwap> CreatePrivToSwapAsync(PrivToSwap privToSwap)
        {
            return privToSwapRepository.CreatePrivToSwapAsync(privToSwap);
        }

        public Task<bool> DeletePrivToSwapAsync(int id)
        {
            return privToSwapRepository.DeletePrivToSwapAsync(id);
        }

        public Task<PrivToSwap> GetPrivToSwapAsync(string adObjName, int productId, int pObjectName)
        {
            return privToSwapRepository.GetPrivToSwapAsync(adObjName, productId, pObjectName);
        }

        public Task<PrivToSwap> GetPrivToSwapAsync(int id)
        {
            return privToSwapRepository.GetPrivToSwapAsync(id);
        }

        public Task<List<PrivToSwap>> GetPrivToSwapsAsync()
        {
            return privToSwapRepository.GetPrivToSwapsAsync();
        }

        public Task<bool> IsPrivToSwapExistAsync(int privToSwapId)
        {
            return privToSwapRepository.IsPrivToSwapExistAsync(privToSwapId);
        }

        public Task<bool> IsPrivToSwapExistAsync(string ownerId, int productId, int pOwnerId)
        {
            return privToSwapRepository.IsPrivToSwapExistAsync(ownerId, productId, pOwnerId);
        }
    }
}
