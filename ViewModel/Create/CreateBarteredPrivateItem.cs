using MoqaydaGP.Repository.Abstract;
using MoqaydaGP.ViewModel.Get;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;

namespace MoqaydaGP.ViewModel.Create
{
    public class CreateBarteredPrivateItem : BarteredPrivateViewModel
    {
        public override async Task<IEnumerable<ValidationResult>> ValidateAsync(ValidationContext validationContext,
     CancellationToken cancellation)
        {
            var errors = new List<ValidationResult>();
            var prodToSwapService = validationContext.GetService<IBarteredPrivService>();
            var userService = validationContext.GetService<IUserService>();
            var productOwnerService = validationContext.GetService<IPrivateItemOwnerService>();
            var user = await userService.GetUserAndProductsAsync(UserId);
            var productOwner = await productOwnerService.GetPrivateItemOwnerAsync(PrivateItemOwnerId);

            if (await prodToSwapService.IsBarteredPrivExistAsync(UserId, ProductId, PrivateItemOwnerId))
            {
                errors.Add(new ValidationResult($"Product id {ProductId} exist for owner {UserId}", new[] { nameof(ProductId) }));
            }
            if (user == null)
            {
                errors.Add(new ValidationResult($"user id {UserId} doesn't exist", new[] { nameof(UserId) }));
            }
            if (productOwner == null)
            {
                errors.Add(new ValidationResult($"ProductOwner id {PrivateItemOwnerId} doesn't exist", new[] { nameof(PrivateItemOwnerId) }));
            }
            return errors;

        }
    }
}
