using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoqaydaGP.Entities;
using MoqaydaGP.Repository.Abstract;
using MoqaydaGP.Repository.Implement;
using MoqaydaGP.ViewModel.Create;
using MoqaydaGP.ViewModel.Get;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoqaydaGP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlockController : ControllerBase
    {
        private readonly IBlockService blockService;

        public BlockController(IBlockService blockService)
        {
            this.blockService = blockService;
            
        }
        // GET: api/<BlockController>
        [HttpGet("", Name = "GetBlock")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<BlockViewModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult> Get()
        {

            var blocks = await blockService.GetBlocksAsync();

            var models = blocks.Select(block => new BlockViewModel()
            {

                Id = block.Id,
               BlockedUserId= block.BlockedUserId,
               BlockingUserId= block.BlockingUserId,


            }).ToList();
            return Ok(models);
        }

       

        // POST api/<BlockController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBlockUser createBlockUser)
        {
            var entityToAdd = new Block()
            {
                
               BlockingUserId=createBlockUser.BlockingUserId,
               BlockedUserId = createBlockUser.BlockedUserId,

            };
            var createdProduct = await blockService.CreateBlockAsync(entityToAdd);
            return new CreatedAtRouteResult("Get", new { Id = createBlockUser.Id });
        }



        // DELETE api/<BlockController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(short id)
        {
            var category = await blockService.GetBlockAsync(id);
            if (category == null)
                return NotFound();
            
            var isSuccess = await blockService.DeleteBlockAsync(id);

            return Ok();
        }
    }
}
