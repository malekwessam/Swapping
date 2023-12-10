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
    public class PrivToSwapController : ControllerBase
    {
        private readonly IPrivToSwapService privToSwapService;
        private readonly IUserService userService;
        public PrivToSwapController(IPrivToSwapService privToSwapService, IUserService userService)
        {
            this.userService = userService;
            this.privToSwapService = privToSwapService;
        }
        // GET: api/<PrivToSwapController>
        [HttpGet("all", Name = "GetPrivToSwaps")]
        [ProducesResponseType(typeof(List<PrivToSwapViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPrivToSwapsAsync()
        {

            var prodToSwaps = await privToSwapService.GetPrivToSwapsAsync();

            var privToSwapsViewModel = prodToSwaps.Select(s => new PrivToSwapViewModel()
            {
                UserId = s.UserId,
                ProductId = Convert.ToInt32(s.ProductId),
                Id = s.Id,
                PrivateItemOwnerId = (int)s.PrivateItemOwnerId
            }).ToList();

            return Ok(privToSwapsViewModel);
        }

        // GET api/<ProdToSwapController>/5

        [HttpPost("", Name = "CreatePrivToSwap")]
        public async Task<IActionResult> PostPrivToSwapAsync([FromBody] CreatePrivToSwap createPrivToSwap)
        {

            var prodToSwapInDB = await privToSwapService.GetPrivToSwapAsync(createPrivToSwap.UserId,
                createPrivToSwap.ProductId, createPrivToSwap.PrivateItemOwnerId);

            if (prodToSwapInDB == null)
            {
                var entity = new PrivToSwap()
                {
                    UserId = createPrivToSwap.UserId,
                    ProductId = createPrivToSwap.ProductId,
                    PrivateItemOwnerId = createPrivToSwap.PrivateItemOwnerId
                };

                var isSuccess = await privToSwapService.CreatePrivToSwapAsync(entity);
                return new CreatedAtRouteResult("GetPrivToSwap",
                  new { id = entity.Id });
            }
            return new CreatedAtRouteResult("GetPrivToSwap",
                   new { id = prodToSwapInDB.Id });
        }

        [HttpGet("{id}", Name = "GetUserPrivateOffers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(User6ViewModel), StatusCodes.Status200OK)]
        public async Task<ActionResult> Get(string id)
        {
            var user = await userService.GetUserAndPrivateOffersAsync(id);
            if (user == null)
                return NotFound();

            var model = new User6ViewModel()
            {
                Id = user.Id,


                UserPrivateOffersViewModels = user.PrivToSwap.Any() ? user.PrivToSwap.Select(s => new UserPrivateOffersViewModel()
                {


                    Id = s.Id,
                    ProductId = (int)s.ProductId,
                    PrivateItemOwnerId = (int)s.PrivateItemOwnerId

                }).ToList() : new List<UserPrivateOffersViewModel>()

            };
            return Ok(model);

        }




        // DELETE api/<ProdToSwapController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await privToSwapService.GetPrivToSwapAsync(id);
            if (product == null)
                return NotFound();

            // System.IO.File.Delete(product.PathImage);
            var isSuccess = await privToSwapService.DeletePrivToSwapAsync(id);
            return Ok();
        }
    }
}
