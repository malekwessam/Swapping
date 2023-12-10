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
    public class BarteredProductController : ControllerBase
    {
        private readonly IBarteredProductService barteredProductService;
        private readonly IUserService userService;
        public BarteredProductController(IBarteredProductService barteredProductService, IUserService userService)
        {
            this.userService = userService;
            this.barteredProductService = barteredProductService;
        }
        // GET: api/<ProdToSwapController>
        [HttpGet("all", Name = "GetBarteredProducts")]
        [ProducesResponseType(typeof(List<BarteredProductViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBarteredProductsAsync()
        {

            var prodToSwaps = await barteredProductService.GetBarteredProductsAsync();

            var prodToSwapsViewModel = prodToSwaps.Select(s => new BarteredProductViewModel()
            {
                UserId = s.UserId,
                ProductId = Convert.ToInt32(s.ProductId),
                Id = s.Id,
                ProductOwnerId = (int)s.ProductOwnerId
            }).ToList();

            return Ok(prodToSwapsViewModel);
        }

        // GET api/<ProdToSwapController>/5

        [HttpPost("", Name = "CreateBarteredProduct")]
        public async Task<IActionResult> PostBarteredProductAsync([FromBody] CreateBarteredProduct createBarteredProduct)
        {

            var prodToSwapInDB = await barteredProductService.GetBarteredProductAsync(createBarteredProduct.UserId,
                createBarteredProduct.ProductId, createBarteredProduct.ProductOwnerId);

            if (prodToSwapInDB == null)
            {
                var entity = new BarteredProduct()
                {
                    UserId = createBarteredProduct.UserId,
                    ProductId = createBarteredProduct.ProductId,
                    ProductOwnerId = createBarteredProduct.ProductOwnerId
                };

                var isSuccess = await barteredProductService.CreateBarteredProductAsync(entity);
                return new CreatedAtRouteResult("GetBarteredProduct",
                  new { id = entity.Id });
            }
            return new CreatedAtRouteResult("GetBarteredProduct",
                   new { id = prodToSwapInDB.Id });
        }

        [HttpGet("{id}", Name = "GetUserBarteredProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(User7ViewModel), StatusCodes.Status200OK)]
        public async Task<ActionResult> Get(string id)
        {
            var user = await userService.GetUserAndBarteredProductsAsync(id);
            if (user == null)
                return NotFound();

            var model = new User7ViewModel()
            {
                Id = user.Id,


                UserBarteredProductViewModels = user.BarteredProduct.Any() ? user.BarteredProduct.Select(s => new UserBarteredProductViewModel()
                {


                    Id = s.Id,
                    ProductId = (int)s.ProductId,
                    ProductOwnerId = (int)s.ProductOwnerId

                }).ToList() : new List<UserBarteredProductViewModel>()

            };
            return Ok(model);

        }


        // DELETE api/<ProdToSwapController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await barteredProductService.GetBarteredProductAsync(id);
            if (product == null)
                return NotFound();

            // System.IO.File.Delete(product.PathImage);
            var isSuccess = await barteredProductService.DeleteBarteredProductAsync(id);
            return Ok();
        }
    }
}
