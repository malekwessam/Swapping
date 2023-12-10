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
    public class BarteredPrivController : ControllerBase
    {
        private readonly IBarteredPrivService barteredPrivService;
        private readonly IUserService userService;
        public BarteredPrivController(IBarteredPrivService barteredPrivService, IUserService userService)
        {
            this.userService = userService;
            this.barteredPrivService = barteredPrivService;
        }
        // GET: api/<BarteredPrivController>
        [HttpGet("all", Name = "GetBarteredPrivs")]
        [ProducesResponseType(typeof(List<BarteredPrivateViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBarteredProductsAsync()
        {

            var prodToSwaps = await barteredPrivService.GetBarteredPrivsAsync();

            var prodToSwapsViewModel = prodToSwaps.Select(s => new BarteredPrivateViewModel()
            {
                UserId = s.UserId,
                ProductId = Convert.ToInt32(s.ProductId),
                Id = s.Id,
                PrivateItemOwnerId = (int)s.PrivateItemOwnerId
            }).ToList();

            return Ok(prodToSwapsViewModel);
        }

        // GET api/<ProdToSwapController>/5

        [HttpPost("", Name = "CreateBarteredPriv")]
        public async Task<IActionResult> PostBarteredPrivAsync([FromBody] CreateBarteredPrivateItem createBarteredPrivateItem)
        {

            var prodToSwapInDB = await barteredPrivService.GetBarteredPrivAsync(createBarteredPrivateItem.UserId,
                createBarteredPrivateItem.ProductId, createBarteredPrivateItem.PrivateItemOwnerId);

            if (prodToSwapInDB == null)
            {
                var entity = new BarteredPriv()
                {
                    UserId = createBarteredPrivateItem.UserId,
                    ProductId = createBarteredPrivateItem.ProductId,
                    PrivateItemOwnerId = createBarteredPrivateItem.PrivateItemOwnerId
                };

                var isSuccess = await barteredPrivService.CreateBarteredPrivAsync(entity);
                return new CreatedAtRouteResult("GetBarteredPriv",
                  new { id = entity.Id });
            }
            return new CreatedAtRouteResult("GetBarteredPriv",
                   new { id = prodToSwapInDB.Id });
        }

        [HttpGet("{id}", Name = "GetUserBarteredPriv")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(User8ViewModel), StatusCodes.Status200OK)]
        public async Task<ActionResult> Get(string id)
        {
            var user = await userService.GetUserAndBarteredPrivateItemsAsync(id);
            if (user == null)
                return NotFound();

            var model = new User8ViewModel()
            {
                Id = user.Id,


                UserBarteredPrivateItemsViewModels = user.BarteredPriv.Any() ? user.BarteredPriv.Select(s => new UserBarteredPrivateItemsViewModel()
                {


                    Id = s.Id,
                    ProductId = (int)s.ProductId,
                    PrivateItemOwnerId = (int)s.PrivateItemOwnerId

                }).ToList() : new List<UserBarteredPrivateItemsViewModel>()

            };
            return Ok(model);

        }


        // DELETE api/<ProdToSwapController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await barteredPrivService.GetBarteredPrivAsync(id);
            if (product == null)
                return NotFound();

            // System.IO.File.Delete(product.PathImage);
            var isSuccess = await barteredPrivService.DeleteBarteredPrivAsync(id);
            return Ok();
        }
    }
}
