using MoqaydaGP.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoqaydaGP.Repository.Abstract
{
    public interface IBlockRepository
    {
        Task<List<Block>> GetBlocksAsync();
        Task<Block> CreateBlockAsync(Block block);
        Task<bool> DeleteBlockAsync(short blockId);
        Task<Block> GetBlockAsync(short blockId);
    }
}
