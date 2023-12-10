using MoqaydaGP.Validation;
using System.Collections.Generic;

namespace MoqaydaGP.ViewModel.Get
{
    public class User3ViewModel : AbstractValidatableObject
    {
        public string Id { get; set; }

        public List<UserWishlistViewModel> UserWishlistViewModels { get; set; }
    }
}
