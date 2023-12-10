using MoqaydaGP.Entities;
using MoqaydaGP.Repository.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoqaydaGP.Repository.Implement
{
    public class BlockService : IBlockService
    {
        private readonly IBlockRepository blockRepository;

        public BlockService(IBlockRepository blockRepository)
        {
            this.blockRepository = blockRepository;
        }
        public Task<Block> CreateBlockAsync(Block block)
        {
            return blockRepository.CreateBlockAsync(block);
        }

        public Task<bool> DeleteBlockAsync(short blockId)
        {
            return blockRepository.DeleteBlockAsync(blockId);
        }

        public Task<Block> GetBlockAsync(short blockId)
        {
            return blockRepository.GetBlockAsync(blockId);
        }

        public Task<List<Block>> GetBlocksAsync()
        {
            return blockRepository.GetBlocksAsync();
        }
    }
}
