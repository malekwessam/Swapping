using MoqaydaGP.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace MoqaydaGP.ViewModel.Get
{
    public class WishlistItemViewModel : AbstractValidatableObject
    {
        public long Id { get; set; }
        public int ProductId { get; set; }
        [MaxLength(200)]
        public string UserId { get; set; }
       
    }
}
