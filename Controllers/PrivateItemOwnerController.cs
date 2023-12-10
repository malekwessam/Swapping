using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoqaydaGP.Entities;
using MoqaydaGP.Repository.Abstract;
using MoqaydaGP.Repository.Implement;
using MoqaydaGP.ViewModel.Create;
using MoqaydaGP.ViewModel.Get;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoqaydaGP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrivateItemOwnerController : ControllerBase
    {
        private readonly IPrivateItemOwnerService privateItemOwnerService;
        private readonly IPrivateItemService privateItemService;
        public PrivateItemOwnerController(IPrivateItemOwnerService privateItemOwnerService, IPrivateItemService privateItemService)
        {
            this.privateItemOwnerService = privateItemOwnerService;
            this.privateItemService = privateItemService;
        }
        // GET: api/<PrivateItemOwnerController>
        [HttpGet("all", Name = "GetPrivateItemOwners")]
        [ProducesResponseType(typeof(List<PrivateItemOwnerViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPrivateItemOwnersAsync()
        {

            var privateItemOwners = await privateItemOwnerService.GetPrivateItemOwnersAsync();

            var privateItemOwnersViewModel = privateItemOwners.Select(s => new PrivateItemOwnerViewModel()
            {
                UserId = s.UserId,
                PrivateItemId = Convert.ToInt32(s.PrivateItemId),
                Id = s.Id,

            }).ToList();

            return Ok(privateItemOwnersViewModel);
        }

        [HttpGet("{id}", Name = "GetPrivateItemOwner")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(PrivateItem1ViewModel), StatusCodes.Status200OK)]
        public async Task<ActionResult> Get(int id)
        {
            var privateItem = await privateItemOwnerService.GetPrivateItemOwnerAsync(id);
            if (privateItem == null)
                return NotFound();
           

            var model = new PrivateItemOwnerViewModel()
            {
                Id = privateItem.Id,
                PrivateItemId= (int)privateItem.PrivateItemId,
                UserId=privateItem.UserId

            };
            return Ok(model);

        }

        [HttpPost("", Name = "CreatePrivateItemOwner")]
        public async Task<IActionResult> PostPrivateItemOwnerAsync([FromBody] CreatePrivateItemOwner createPrivateItemOwner)
        {

            var productOwnerInDB = await privateItemOwnerService.GetPrivateItemOwnerAsync(createPrivateItemOwner.UserId,
                createPrivateItemOwner.PrivateItemId);

            if (productOwnerInDB == null)
            {
                var entity = new PrivateItemOwner()
                {
                    UserId = createPrivateItemOwner.UserId,
                    PrivateItemId = createPrivateItemOwner.PrivateItemId
                };

                var isSuccess = await privateItemOwnerService.CreatePrivateItemOwnerAsync(entity);
                return new CreatedAtRouteResult("GetPrivateItemOwner",
                  new { id = entity.Id });
            }
            return new CreatedAtRouteResult("GetPrivateItemOwner",
                   new { id = productOwnerInDB.Id });
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await privateItemOwnerService.GetPrivateItemOwnerAsync(id);
            if (product == null)
                return NotFound();

            // System.IO.File.Delete(product.PathImage);
            var isSuccess = await privateItemOwnerService.DeletePrivateItemOwnerAsync(id);
            return Ok();
        }
    }
}
