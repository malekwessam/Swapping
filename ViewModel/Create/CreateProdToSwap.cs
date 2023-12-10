using MoqaydaGP.Repository.Abstract;
using MoqaydaGP.ViewModel.Get;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;

namespace MoqaydaGP.ViewModel.Create
{
    public class CreateProdToSwap : ProdToSwapViewModel
    {
        public override async Task<IEnumerable<ValidationResult>> ValidateAsync(ValidationContext validationContext,
       CancellationToken cancellation)
        {
            var errors = new List<ValidationResult>();
            var prodToSwapService = validationContext.GetService<IProdToSwapService>();
            var userService = validationContext.GetService<IUserService>();
            var productOwnerService = validationContext.GetService<IProductOwnerService>();
            var user = await userService.GetUserAndProductsAsync(UserId);
            var productOwner = await productOwnerService.GetProductOwnerAsync(ProductOwnerId);

            if (await prodToSwapService.IsProdToSwapExistAsync(UserId, ProductId, ProductOwnerId))
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
