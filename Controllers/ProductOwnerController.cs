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
    public class ProductOwnerController : ControllerBase
    {
        // GET: api/<ProductOwnerController>
        private readonly IProductOwnerService productOwnerService;
        private readonly IUserService userService;
        public ProductOwnerController(IProductOwnerService productOwnerService, IUserService userService)
        {
            this.productOwnerService = productOwnerService;
            this.userService = userService;
        }
        [HttpGet("all", Name = "GetProductOwners")]
        [ProducesResponseType(typeof(List<ProductOwnerViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductOwnersAsync()
        {

            var productOwners = await productOwnerService.GetProductOwnersAsync();

            var productOwnersViewModel = productOwners.Select(s => new ProductOwnerViewModel()
            {
                UserId = s.UserId,
                ProductId = Convert.ToInt32(s.ProductId),
                Id = s.Id,

            }).ToList();

            return Ok(productOwnersViewModel);
        }
        [HttpGet("{id}", Name = "GetProductOwner")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProductOwnerViewModel), StatusCodes.Status200OK)]
        public async Task<ActionResult> Get(int id)
        {
            var user = await productOwnerService.GetProductOwnerAsync(id);
            if (user == null)
                return NotFound();

            var model = new ProductOwnerViewModel()
            {
                Id = user.Id,
                UserId = user.UserId,
                    ProductId = (int)user.ProductId


                

            };
            return Ok(model);

        }



        [HttpPost("", Name = "CreateProductOwner")]
        public async Task<IActionResult> PostProductOwnerAsync([FromBody] CreateProductOwner createProductOwner)
        {

            var productOwnerInDB = await productOwnerService.GetProductOwnerAsync(createProductOwner.UserId,
                createProductOwner.ProductId);

            if (productOwnerInDB == null)
            {
                var entity = new ProductOwner()
                {
                    UserId = createProductOwner.UserId,
                    ProductId = createProductOwner.ProductId
                };

                var isSuccess = await productOwnerService.CreateProductOwnerAsync(entity);
                return new CreatedAtRouteResult("GetProductOwner",
                  new { id = entity.Id });
            }
            return new CreatedAtRouteResult("GetProductOwner",
                   new { id = productOwnerInDB.Id });
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await productOwnerService.GetProductOwnerAsync(id);
            if (product == null)
                return NotFound();

            // System.IO.File.Delete(product.PathImage);
            var isSuccess = await productOwnerService.DeleteProductOwnerAsync(id);
            return Ok();
        }
    }
}
