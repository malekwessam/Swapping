using MoqaydaGP.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoqaydaGP.ViewModel.Get
{
    public class PrivateItemViewModel : AbstractValidatableObject
    {
        public int Id { get; set; }
        [Required]
      
        public string Name { get; set; }
        [Required]

        public string Descriptions { get; set; }

        public string pathImage { get; set; }
        [Required]
        public string UserId { get; set; }

        
    }
}
