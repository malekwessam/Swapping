using MoqaydaGP.Entities;
using MoqaydaGP.Repository.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Threading;
using MoqaydaGP.ViewModel.Get;
using Microsoft.Extensions.DependencyInjection;

namespace MoqaydaGP.ViewModel.Create
{
    public class CreatePrivateItemOwner : PrivateItemOwnerViewModel
    {
        public override async Task<IEnumerable<ValidationResult>> ValidateAsync(ValidationContext validationContext,
      CancellationToken cancellation)
        {
            var errors = new List<ValidationResult>();
            var productOwnerService = validationContext.GetService<IPrivateItemOwnerService>();
            var userService = validationContext.GetService<IUserService>();
            var user = await userService.GetUserAndProductsAsync(UserId);

            if (await productOwnerService.IsPrivateItemOwnerExistAsync(UserId, PrivateItemId))
            {
                errors.Add(new ValidationResult($"PrivateItem id {PrivateItemId} exist for owner {UserId}", new[] { nameof(PrivateItemId) }));
            }
            if (user == null)
            {
                errors.Add(new ValidationResult($"user id {UserId} doesn't exist", new[] { nameof(UserId) }));
            }
            return errors;

        }
    }
}
