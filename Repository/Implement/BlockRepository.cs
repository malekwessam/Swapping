using Microsoft.EntityFrameworkCore;
using MoqaydaGP.Data;
using MoqaydaGP.Entities;
using MoqaydaGP.Repository.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoqaydaGP.Repository.Implement
{
    public class BlockRepository: IBlockRepository
    {
        private readonly MoqaydaDbContext DbContext;
        public BlockRepository(MoqaydaDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task<Block> CreateBlockAsync(Block block)
        {
            DbContext.Block.Add(block);
            await DbContext.SaveChangesAsync();
            return block;
        }

        public async Task<bool> DeleteBlockAsync(short blockId)
        {
            var blockToRemove = await DbContext.Block.FindAsync(blockId);
            DbContext.Block.Remove(blockToRemove);
            return await DbContext.SaveChangesAsync() > 0;
        }

        public Task<Block> GetBlockAsync(short blockId)
        {
            return this.DbContext.Block.FindAsync(blockId).AsTask();
        }

        public Task<List<Block>> GetBlocksAsync()
        {
            return this.DbContext.Block.ToListAsync();
        }
    }
}
