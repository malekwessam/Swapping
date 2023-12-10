using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoqaydaGP.Entities;
using MoqaydaGP.Repository.Abstract;
using MoqaydaGP.ViewModel.Create;
using MoqaydaGP.ViewModel.Get;
using MoqaydaGP.ViewModel.Update;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoqaydaGP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        [Obsolete]
        private readonly IHostingEnvironment hostingEnvironment;
        [Obsolete]
        public ProductController(IProductService productService, IHostingEnvironment hostingEnvironment)
        {
            this.productService = productService;
            this.hostingEnvironment = hostingEnvironment;
        }
        // GET: api/<ProductController>
        [HttpGet("", Name = "GetProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ProductViewModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult> Get()
        {

            var products = await productService.GetProductsAsync();
            var models = products.Select(product => new ProductViewModel()
            {
                Id = product.Id,
                Name = product.ProductName == null ? null : product.ProductName,
                pathImage = product.PathImage == null ? null : "http://www.moqayda.somee.com/" + product.PathImage,
                Descriptions = product.ProductDescription == null ? null : product.ProductDescription,
                AvailableSince = (DateTime)product.AvailableSince,
                IsActive = (bool)product.IsActive,
                ProductBackgroundColor = product.ProductBgColor ?? 0,
                CategoryId = Convert.ToInt16(product.CategoryId),
                IsFavourite = product.IsWishlistItem,
                ProductToSwap = product.ProductToSwap == null ? null : product.ProductToSwap,
                UserId = product.UserId == null ? null : product.UserId
            }).ToList();
            return Ok(models);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}", Name = "GetProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Product1ViewModel), StatusCodes.Status200OK)]
        public async Task<ActionResult> Get(int id)
        {
            var product = await productService.GetProductAndOwnerAsync(id);
            if (product == null)
                return NotFound();
            var nn = "http://www.moqayda.somee.com/" + product.PathImage;
            var model = new Product1ViewModel()
            {

                Id = product.Id,
                Name = product.ProductName == null ? null : product.ProductName,
                pathImage = product.PathImage == null ? null : nn,
                Descriptions = product.ProductDescription == null ? null : product.ProductDescription,
                AvailableSince = (DateTime)product.AvailableSince,
                IsActive = (bool)product.IsActive,
                CategoryId = Convert.ToInt16(product.CategoryId),
                IsFavourite = product.IsWishlistItem,
                ProductToSwap = product.ProductToSwap == null ? null : product.ProductToSwap,
                UserId = product.UserId == null ? null : product.UserId,

                 ProductAndOwnerViewModels = product.ProductOwner.Any() ? product.ProductOwner.Select(s => new ProductAndOwnerViewModel()
                 {

                    Id=s.Id,
                    ProductId=product.Id,
                    UserId= s.UserId

                    
                 }).ToList() : new List<ProductAndOwnerViewModel>()
            };
            return Ok(model);

        }

        // POST api/<ProductController>
        [HttpPost("", Name = "CreateProduct")]
        public async Task<ActionResult> Post([FromForm] CreateProduct createProduct, IFormFile image)
        {
            Random random = new Random();
            int rNum = random.Next();
            var images = "PImages/" + rNum + image.FileName;
            var pathImage = Path.Combine(hostingEnvironment.WebRootPath, images);
            var streamImage = new FileStream(pathImage, FileMode.Append);
            image.CopyTo(streamImage);

            var entityToAdd = new Product()
            {

                ProductName = createProduct.Name,
                PathImage = images,
                ProductDescription = createProduct.Descriptions,
                CreatedDate = DateTime.Now,
                AvailableSince = DateTime.Now,
                IsActive = createProduct.IsActive,
                CategoryId = createProduct.CategoryId,
                ProductBgColor = createProduct.ProductBackgroundColor,
                IsWishlistItem = createProduct.IsFavourite,
                ProductToSwap = createProduct.ProductToSwap,
                UserId = createProduct.UserId,
            };

            var createdProduct = await productService.CreateProductAsync(entityToAdd);
            return new CreatedAtRouteResult("Get", new { Id = createProduct.Id });
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromForm] UpdateProduct updateProduct, IFormFile image)
        {
            string images = null;
            if (image != null)
            {
                Random random = new Random();
                int rNum = random.Next();
                images = "PImages/" + rNum + image.FileName;
                var pathImage = Path.Combine(hostingEnvironment.WebRootPath, images);
                var streamImage = new FileStream(pathImage, FileMode.Append);
                image.CopyTo(streamImage);
            }
            var entityToUpdate = await productService.GetProductAsync(updateProduct.Id);



            entityToUpdate.ProductName = updateProduct.Name;

            entityToUpdate.PathImage = images;
            entityToUpdate.CategoryId = updateProduct.CategoryId;
            entityToUpdate.ModifiedDate = DateTime.Now;

            entityToUpdate.ProductDescription = updateProduct.Descriptions;
            entityToUpdate.IsActive = updateProduct.IsActive;
            entityToUpdate.IsWishlistItem = updateProduct.IsFavourite;
            entityToUpdate.ProductToSwap = updateProduct.ProductToSwap;
            entityToUpdate.ProductBgColor = updateProduct.ProductBackgroundColor;

            var updatedProduct = await productService.UpdateProductAsync(entityToUpdate);
            return Ok();
        }


        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await productService.GetProductAsync(id);
            if (product == null)
                return NotFound();

            // System.IO.File.Delete(product.PathImage);
            var isSuccess = await productService.DeleteProductAsync(id);
            return Ok();
        }
    }
}
