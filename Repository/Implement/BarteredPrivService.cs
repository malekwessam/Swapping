using MoqaydaGP.Entities;
using MoqaydaGP.Repository.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoqaydaGP.Repository.Implement
{
    public class BarteredPrivService: IBarteredPrivService
    {
        private readonly IBarteredPrivRepository barteredPrivRepository;

        public BarteredPrivService(IBarteredPrivRepository barteredPrivRepository)
        {
            this.barteredPrivRepository = barteredPrivRepository;
        }

        public Task<BarteredPriv> CreateBarteredPrivAsync(BarteredPriv barteredPriv)
        {
            return barteredPrivRepository.CreateBarteredPrivAsync(barteredPriv);
        }

        public Task<bool> DeleteBarteredPrivAsync(int id)
        {
            return barteredPrivRepository.DeleteBarteredPrivAsync(id);
        }

        public Task<BarteredPriv> GetBarteredPrivAsync(string adObjName, int productId, int pObjectName)
        {
            return barteredPrivRepository.GetBarteredPrivAsync(adObjName, productId, pObjectName);
        }

        public Task<BarteredPriv> GetBarteredPrivAsync(int id)
        {
            return barteredPrivRepository.GetBarteredPrivAsync(id);
        }

        public Task<List<BarteredPriv>> GetBarteredPrivsAsync()
        {
            return barteredPrivRepository.GetBarteredPrivsAsync();
        }

        public Task<bool> IsBarteredPrivExistAsync(int barteredPrivId)
        {
            return barteredPrivRepository.IsBarteredPrivExistAsync(barteredPrivId);
        }

        public Task<bool> IsBarteredPrivExistAsync(string ownerId, int productId, int pOwnerId)
        {
            return barteredPrivRepository.IsBarteredPrivExistAsync(ownerId, productId, pOwnerId);
        }
    }
}
