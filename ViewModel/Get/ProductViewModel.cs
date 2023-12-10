using MoqaydaGP.Validation;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace MoqaydaGP.ViewModel.Get
{
    public class ProductViewModel : AbstractValidatableObject
    {
        public int Id { get; set; }
        [Required]
       
        public string Name { get; set; }
        [Required]

        public string Descriptions { get; set; }
        [Required]
        public string pathImage { get; set; }
        public DateTime AvailableSince { get; set; }
        public bool IsActive { get; set; } = true;
        public short CategoryId { get; set; }
        public int ProductBackgroundColor { get; set; }
        public bool IsFavourite { get; set; } = false;
        public string ProductToSwap { get; set; }
        public string UserId { get; set; }

       
    }
}
