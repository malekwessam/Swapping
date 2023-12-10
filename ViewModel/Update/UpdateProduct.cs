using MoqaydaGP.Repository.Abstract;
using MoqaydaGP.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;

namespace MoqaydaGP.ViewModel.Update
{
    public class UpdateProduct : AbstractValidatableObject
    {
        public int Id { get; set; }
        [MinLength(3)]
        public string Name { get; set; }
        public string Descriptions { get; set; }
        public bool IsActive { get; set; }
        public short CategoryId { get; set; }
        public int ProductBackgroundColor { get; set; }
        public bool IsFavourite { get; set; }
        public string ProductToSwap { get; set; }


















        public override async Task<IEnumerable<ValidationResult>> ValidateAsync(
         ValidationContext validationContext,
         CancellationToken cancellation)
        {
            var errors = new List<ValidationResult>();

            var productService = validationContext.GetService<IProductService>();


            var productEntity = await productService.GetProductAsync(Id);

            if (productEntity == null)
            {
                errors.Add(new ValidationResult($"No such product id {Id} exist", new[] { nameof(Id) }));
            }




            return errors;
        }
    }
}
