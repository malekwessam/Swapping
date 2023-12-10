using MoqaydaGP.Repository.Abstract;
using MoqaydaGP.ViewModel.Get;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;

namespace MoqaydaGP.ViewModel.Create
{
    public class CreateProductOwner : ProductOwnerViewModel
    {
        public override async Task<IEnumerable<ValidationResult>> ValidateAsync(ValidationContext validationContext,
       CancellationToken cancellation)
        {
            var errors = new List<ValidationResult>();
            var productOwnerService = validationContext.GetService<IProductOwnerService>();
            var userService = validationContext.GetService<IUserService>();

            var user = await userService.GetUserAndProductsAsync(UserId);

            if (await productOwnerService.IsProductOwnerExistAsync(UserId, ProductId))
            {
                errors.Add(new ValidationResult($"Product id {ProductId} exist for owner {UserId}", new[] { nameof(ProductId) }));
            }
            if (user == null)
            {
                errors.Add(new ValidationResult($"user id {UserId} doesn't exist", new[] { nameof(UserId) }));
            }
            return errors;

        }
    }
}
