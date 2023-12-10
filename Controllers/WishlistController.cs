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
    public class WishlistController : ControllerBase
    {
        // GET: api/<WishlistController>
        private readonly IWishlistService wishlistService;
        private readonly IUserService userService;
        public WishlistController(IWishlistService wishlistService, IUserService userService)
        {
            this.userService = userService;
            this.wishlistService = wishlistService;
        }
        [HttpGet("all", Name = "GetWishlists")]
        [ProducesResponseType(typeof(List<WishlistItemViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetWishlistItemsAsync()
        {

            var wishlists = await wishlistService.GetWishlistItemsAsync();

            var wishlistsViewModel = wishlists.Select(s => new WishlistItemViewModel()
            {
                UserId = s.UserId,
                ProductId = Convert.ToInt32(s.ProductId),
                Id = s.Id,
              
            }).ToList();

            return Ok(wishlistsViewModel);
        }
        [HttpGet("{id}", Name = "GetUserWishlist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(User3ViewModel), StatusCodes.Status200OK)]
        public async Task<ActionResult> Get(string id)
        {
            var user = await userService.GetUserAndWishlistItemsAsync(id);
            if (user == null)
                return NotFound();

            var model = new User3ViewModel()
            {
                Id = user.Id,


                UserWishlistViewModels = user.WishlistItem.Any() ? user.WishlistItem.Select(s => new UserWishlistViewModel()
                {


                    Id = s.Id,
                    ProductId = (int)s.ProductId


                }).ToList() : new List<UserWishlistViewModel>()

            };
            return Ok(model);

        }

        [HttpPost("", Name = "CreateWishlist")]
        public async Task<IActionResult> PostWishlistAsync([FromBody] CreateWishlistItem createWishlistItem)
        {

            var wishListInDB = await wishlistService.GetWishlistItemAsync(createWishlistItem.UserId,
                createWishlistItem.ProductId);

            if (wishListInDB == null)
            {
                var entity = new WishlistItem()
                {
                    UserId = createWishlistItem.UserId,
                    ProductId = createWishlistItem.ProductId
                };

                var isSuccess = await wishlistService.CreateWishlistItemAsync(entity);
                return new CreatedAtRouteResult("GetWishlist",
                  new { id = entity.Id });
            }
            return new CreatedAtRouteResult("GetWishlist",
                   new { id = wishListInDB.Id });
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(long id)
        {
            var product = await wishlistService.GetWishlistItemAsync(id);
            if (product == null)
                return NotFound();

            // System.IO.File.Delete(product.PathImage);
            var isSuccess = await wishlistService.DeleteWishlistItemAsync(id);
            return Ok();
        }
    }
}
