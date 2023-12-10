using MoqaydaGP.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoqaydaGP.Repository.Abstract
{
    public interface IBarteredPrivService
    {
        Task<List<BarteredPriv>> GetBarteredPrivsAsync();
        Task<BarteredPriv> CreateBarteredPrivAsync(BarteredPriv barteredPriv);
        Task<bool> IsBarteredPrivExistAsync(int barteredPrivId);
        Task<bool> DeleteBarteredPrivAsync(int id);
        Task<bool> IsBarteredPrivExistAsync(string ownerId, int productId, int pOwnerId);
        Task<BarteredPriv> GetBarteredPrivAsync(string adObjName, int productId, int pObjectName);
        Task<BarteredPriv> GetBarteredPrivAsync(int id);
    }
}
