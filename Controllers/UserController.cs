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
    public class UserController : ControllerBase
    {
        // GET: api/<UserController>
        private readonly IUserService userService;

        private readonly IHostingEnvironment hostingEnvironment;

        public UserController(IUserService userService, IHostingEnvironment hostingEnvironment)
        {
            this.userService = userService;
            this.hostingEnvironment = hostingEnvironment;
        }
        // GET: api/<UserController>
        [HttpGet("", Name = "GetUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<User1ViewModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult> Get()
        {
            var users = await userService.GetUsersAsync();

            var models = users.Select(user => new User1ViewModel()
            {

                Id = user.Id,
                firstName = user.firstName == null ? null : user.firstName,
                lastName = user.lastName == null ? null : user.lastName,
                PathImage = user.PathImage == null ? null : "http://www.moqayda.somee.com/" + user.PathImage,
                country = user.country == null ? null : user.country,
                city = user.city == null ? null : user.city,
                address = user.address == null ? null : user.address,
                phoneNumber = user.phoneNumber == null ? null : user.phoneNumber,
                email = user.email == null ? null : user.email,

            }).ToList();
            return Ok(models);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}", Name = "GetUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(User2ViewModel), StatusCodes.Status200OK)]
        public async Task<ActionResult> Get(string id)
        {
            var user = await userService.GetUserAndProductsAsync(id);
            if (user == null)
                return NotFound();
            var nn = "http://www.moqayda.somee.com/" + user.PathImage;

            var model = new User2ViewModel()
            {
                Id = user.Id,
                firstName = user.firstName == null ? null : user.firstName,
                lastName = user.lastName == null ? null : user.lastName,
                email = user.email == null ? null : user.email,
                PathImage = user.PathImage == null ? null : nn,
                country = user.country == null ? null : user.country,
                city = user.city == null ? null : user.city,
                address = user.address == null ? null : user.address,
                phoneNumber = user.phoneNumber == null ? null : user.phoneNumber,

                UserProductViewModels = user.Product.Any() ? user.Product.Select(s => new UserProductViewModel()
                {


                    Id = s.Id,
                    Name = s.ProductName,
                    Descriptions = s.ProductDescription,
                    pathImage = "http://www.moqayda.somee.com/" + s.PathImage,
                    AvailableSince = (System.DateTime)s.AvailableSince,
                    IsActive = (bool)s.IsActive,
                    CategoryId = (short)s.CategoryId,
                    UserId = user.Id,
                    ProductToSwap=s.ProductToSwap,
                }).OrderByDescending(o => o.AvailableSince).ToList() : new List<UserProductViewModel>()

            };
            return Ok(model);
        }


        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] CreateUser createUser, IFormFile image)
        {
            Random random = new Random();
            int rNum = random.Next();
            var images = "UImages/" + rNum + image.FileName;
            var pathImage = Path.Combine(hostingEnvironment.WebRootPath, images);
            var streamImage = new FileStream(pathImage, FileMode.Append);
            image.CopyTo(streamImage);
            var entityToAdd = new User()
            {
                Id = createUser.Id,
                firstName = createUser.firstName,
                lastName = createUser.lastName,
                password = createUser.password,
                email = createUser.email,
                PathImage = images,
                country = createUser.country,
                city = createUser.city,
                address = createUser.address,
                phoneNumber = createUser.phoneNumber,

            };
            var createdUser = await userService.CreateUserAsync(entityToAdd);
            return new CreatedAtRouteResult("Get", new { Id = createUser.Id });
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromForm] UpdateUser updateUser, IFormFile image)
        {

            string images = null;
            if (image != null)
            {
                Random random = new Random();
                int rNum = random.Next();
                images = "UImages/" + rNum + image.FileName;
                var pathImage = Path.Combine(hostingEnvironment.WebRootPath, images);
                var streamImage = new FileStream(pathImage, FileMode.Append);
                image.CopyTo(streamImage);
            }
            var entityToUpdate = await userService.GetUserAndProductsAsync(updateUser.Id);


            entityToUpdate.Id = updateUser.Id;
            entityToUpdate.firstName = updateUser.firstName;
            entityToUpdate.lastName = updateUser.lastName;
            entityToUpdate.password = updateUser.password;
            entityToUpdate.email = updateUser.email;
            entityToUpdate.PathImage = images;
            entityToUpdate.country = updateUser.country;
            entityToUpdate.city = updateUser.city;
            entityToUpdate.address = updateUser.address;
            entityToUpdate.phoneNumber = updateUser.phoneNumber;

            var updatedCategory = await userService.UpdateUserAsync(entityToUpdate);
            return Ok();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(string id)
        {
            var user = await userService.GetUserAndProductsAsync(id);
            if (user == null)
                return NotFound();

            var isSuccess = await userService.DeleteUserAsync(id);

            return Ok();
        }

    }
}
