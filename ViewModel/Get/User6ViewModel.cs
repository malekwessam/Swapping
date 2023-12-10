using MoqaydaGP.Validation;
using System.Collections.Generic;

namespace MoqaydaGP.ViewModel.Get
{
    public class User6ViewModel : AbstractValidatableObject
    
    {
        public string Id { get; set; }


        public List<UserPrivateOffersViewModel> UserPrivateOffersViewModels { get; set; }
    }
}
