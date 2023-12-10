using MoqaydaGP.Entities;
using MoqaydaGP.Repository.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using MoqaydaGP.ViewModel.Get;

namespace MoqaydaGP.ViewModel.Create
{
    public class CreateBarteredProduct : BarteredProductViewModel
    {
        public override async Task<IEnumerable<ValidationResult>> ValidateAsync(ValidationContext validationContext,
      CancellationToken cancellation)
        {
            var errors = new List<ValidationResult>();
            var prodToSwapService = validationContext.GetService<IBarteredProductService>();
            var userService = validationContext.GetService<IUserService>();
            var productOwnerService = validationContext.GetService<IProductOwnerService>();
            var user = await userService.GetUserAndProductsAsync(UserId);
            var productOwner = await productOwnerService.GetProductOwnerAsync(ProductOwnerId);

            if (await prodToSwapService.IsBarteredProductExistAsync(UserId, ProductId, ProductOwnerId))
            {
                errors.Add(new ValidationResult($"Product id {ProductId} exist for owner {UserId}", new[] { nameof(ProductId) }));
            }
            if (user == null)
            {
                errors.Add(new ValidationResult($"user id {UserId} doesn't exist", new[] { nameof(UserId) }));
            }
            if (productOwner == null)
            {
                errors.Add(new ValidationResult($"ProductOwner id {ProductOwnerId} doesn't exist", new[] { nameof(ProductOwnerId) }));
            }
            return errors;

        }
    }
}
