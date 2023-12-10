using MoqaydaGP.Repository.Abstract;
using MoqaydaGP.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;

namespace MoqaydaGP.ViewModel.Create
{
    public class CreatePrivateItem : AbstractValidatableObject
    {
        public int Id { get; set; }
        [Required]
        
        public string Name { get; set; }
        [Required]

        public string Descriptions { get; set; }

        public string pathImage { get; set; }
        [Required]
        public string UserId { get; set; }




        public override async Task<IEnumerable<ValidationResult>> ValidateAsync(ValidationContext validationContext,
     CancellationToken cancellation)
        {
            var errors = new List<ValidationResult>();
            var userService = validationContext.GetService<IUserService>();
            var user = await userService.GetUserAndProductsAsync(UserId);
            if (user == null)
            {
                errors.Add(new ValidationResult($"user id {UserId} doesn't exist", new[] { nameof(UserId) }));
            }


            return errors;
        }
    }
}
