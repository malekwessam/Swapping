using MoqaydaGP.Validation;
using System.ComponentModel.DataAnnotations;

namespace MoqaydaGP.ViewModel.Update
{
    public class UpdatePrivateItem : AbstractValidatableObject
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        public string Name { get; set; }
        [Required]

        public string Descriptions { get; set; }

        public string pathImage { get; set; }
    }
}
