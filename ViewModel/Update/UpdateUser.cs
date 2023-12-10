using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MoqaydaGP.Repository.Abstract;
using MoqaydaGP.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;

namespace MoqaydaGP.ViewModel.Update
{
    public class UpdateUser : AbstractValidatableObject
    {
        public string Id { get; set; }
        public string firstName { get; set; }

        public string lastName { get; set; }

        [DataType(DataType.Password)]
        public string password { get; set; }
        public string phoneNumber { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string address { get; set; }

        
        public string email { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string PathImage { get; set; }




        public override async Task<IEnumerable<ValidationResult>> ValidateAsync(
        ValidationContext validationContext,
        CancellationToken cancellation)
        {
            var errors = new List<ValidationResult>();

            var userService = validationContext.GetService<IUserService>();


            var userEntity = await userService.GetUserAndProductsAsync(Id);

            if (userEntity == null)
            {
                errors.Add(new ValidationResult($"No such user id {Id} exist", new[] { nameof(Id) }));
            }




            return errors;
        }
    }
}
