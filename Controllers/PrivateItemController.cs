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
    public class PrivateItemController : ControllerBase
    {
        private readonly IPrivateItemService privateItemService;
        private readonly IUserService userService;
        private readonly IHostingEnvironment hostingEnvironment;

        public PrivateItemController(IPrivateItemService privateItemService, IHostingEnvironment hostingEnvironment, IUserService userService)
        {
            this.userService = userService;
            this.privateItemService = privateItemService;
            this.hostingEnvironment = hostingEnvironment;
        }
        // GET: api/<PrivateItemController>
        [HttpGet("", Name = "GetPrivateItems")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<PrivateItemViewModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult> Get()
        {

            var privateItems = await privateItemService.GetPrivateItemsAsync();

            var models = privateItems.Select(privateItem => new PrivateItemViewModel()
            {

                Id = privateItem.Id,
                Name = privateItem.PrivateItemeName == null ? null : privateItem.PrivateItemeName,
                Descriptions = privateItem.PrivateItemDescription,
                pathImage = privateItem.PathImage == null ? null : "http://www.moqayda.somee.com/" + privateItem.PathImage,
                UserId = privateItem.UserId,


            }).ToList();
            return Ok(models);
        }

        [HttpGet("{id}", Name = "GetPrivateItemAndOwner")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(PrivateItem1ViewModel), StatusCodes.Status200OK)]
        public async Task<ActionResult> Get(int id)
        {
            var privateItem = await privateItemService.GetPrivateItemAndOwnerAsync(id);
            if (privateItem == null)
                return NotFound();
            var nn = "http://www.moqayda.somee.com/" + privateItem.PathImage;

            var model = new PrivateItem1ViewModel()
            {
                Id = privateItem.Id,
                Name = privateItem.PrivateItemeName,
                Descriptions = privateItem.PrivateItemDescription,
                UserId = privateItem.UserId,
                pathImage = privateItem.PathImage == null ? null : nn,
                PrivateItemAndOwnerViewModels = privateItem.PrivateItemOwner.Any() ? privateItem.PrivateItemOwner.Select(s => new PrivateItemAndOwnerViewModel()
                {


                    Id = s.Id,
                    PrivateItemId = privateItem.Id,
                    UserId = s.UserId,



                }).ToList() : new List<PrivateItemAndOwnerViewModel>()

            };
            return Ok(model);

        }

        // POST api/<PrivateItemController>
        [HttpPost("", Name = "CreatePrivateItem")]
        public async Task<ActionResult> Post([FromForm] CreatePrivateItem createPrivateItem, IFormFile image)
        {
            Random random = new Random();
            int rNum = random.Next();
            var images = "PrImages/" + rNum + image.FileName;
            var pathImage = Path.Combine(hostingEnvironment.WebRootPath, images);
            var streamImage = new FileStream(pathImage, FileMode.Append);
            image.CopyTo(streamImage);

            var entityToAdd = new PrivateItem()
            {

                PrivateItemeName = createPrivateItem.Name,
                PathImage = images,
                PrivateItemDescription = createPrivateItem.Descriptions,

                UserId = createPrivateItem.UserId,
            };

            var createdProduct = await privateItemService.CreatePrivateItemAsync(entityToAdd);
            return new CreatedAtRouteResult("Get", new { Id = createPrivateItem.Id });
        }

        // PUT api/<PrivateItemController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromForm] UpdatePrivateItem updatePrivateItem, IFormFile image)
        {
            string images = null;
            if (image != null)
            {
                Random random = new Random();
                int rNum = random.Next();
                images = "PrImages/" + rNum + image.FileName;
                var pathImage = Path.Combine(hostingEnvironment.WebRootPath, images);
                var streamImage = new FileStream(pathImage, FileMode.Append);
                image.CopyTo(streamImage);
            }
            var entityToUpdate = await privateItemService.GetPrivateItemAsync(updatePrivateItem.Id);



            entityToUpdate.PrivateItemeName = updatePrivateItem.Name;

            entityToUpdate.PathImage = images;


            entityToUpdate.PrivateItemDescription = updatePrivateItem.Descriptions;


            var updatedProduct = await privateItemService.UpdatePrivateItemAsync(entityToUpdate);
            return Ok();
        }

   


        // DELETE api/<PrivateItemController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await privateItemService.GetPrivateItemAsync(id);
            if (product == null)
                return NotFound();

            // System.IO.File.Delete(product.PathImage);
            var isSuccess = await privateItemService.DeletePrivateItemAsync(id);
            return Ok();
        }
    }
}
