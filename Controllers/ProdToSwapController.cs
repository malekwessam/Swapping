using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoqaydaGP.Entities;
using MoqaydaGP.Repository.Abstract;
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
    public class ProdToSwapController : ControllerBase
    {
        private readonly IProdToSwapService prodToSwapService;
        private readonly IUserService userService;
        public ProdToSwapController(IProdToSwapService prodToSwapService, IUserService userService)
        {
            this.userService = userService;
            this.prodToSwapService = prodToSwapService;
        }
        // GET: api/<ProdToSwapController>
        [HttpGet("all", Name = "GetProdToSwaps")]
        [ProducesResponseType(typeof(List<ProdToSwapViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProdToSwapsAsync()
        {

            var prodToSwaps = await prodToSwapService.GetProdToSwapsAsync();

            var prodToSwapsViewModel = prodToSwaps.Select(s => new ProdToSwapViewModel()
            {
                UserId = s.UserId,
                ProductId = Convert.ToInt32(s.ProductId),
                Id = s.Id,
                ProductOwnerId = (int)s.ProductOwnerId
            }).ToList();

            return Ok(prodToSwapsViewModel);
        }

        // GET api/<ProdToSwapController>/5

        [HttpPost("", Name = "CreateProdToSwap")]
        public async Task<IActionResult> PostProdToSwapAsync([FromBody] CreateProdToSwap createProdToSwap)
        {

            var prodToSwapInDB = await prodToSwapService.GetProdToSwapAsync(createProdToSwap.UserId,
                createProdToSwap.ProductId, createProdToSwap.ProductOwnerId);

            if (prodToSwapInDB == null)
            {
                var entity = new ProdToSwap()
                {
                    UserId = createProdToSwap.UserId,
                    ProductId = createProdToSwap.ProductId,
                    ProductOwnerId = createProdToSwap.ProductOwnerId
                };

                var isSuccess = await prodToSwapService.CreateProdToSwapAsync(entity);
                return new CreatedAtRouteResult("GetProdToSwap",
                  new { id = entity.Id });
            }
            return new CreatedAtRouteResult("GetProdToSwap",
                   new { id = prodToSwapInDB.Id });
        }

        [HttpGet("{id}", Name = "GetUserSwapOffers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(User4ViewModel), StatusCodes.Status200OK)]
        public async Task<ActionResult> Get(string id)
        {
            var user = await userService.GetUserAndProdOffersAsync(id);
            if (user == null)
                return NotFound();

            var model = new User4ViewModel()
            {
                Id = user.Id,


                UserProdOffersViewModels = user.ProdToSwap.Any() ? user.ProdToSwap.Select(s => new UserProdOffersViewModel()
                {


                    Id = s.Id,
                    ProductId = (int)s.ProductId,
                    ProductOwnerId = (int)s.ProductOwnerId

                }).ToList() : new List<UserProdOffersViewModel>()

            };
            return Ok(model);

        }


        // DELETE api/<ProdToSwapController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await prodToSwapService.GetProdToSwapAsync(id);
            if (product == null)
                return NotFound();

            // System.IO.File.Delete(product.PathImage);
            var isSuccess = await prodToSwapService.DeleteProdToSwapAsync(id);
            return Ok();
        }
    }
}
