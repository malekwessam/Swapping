using MoqaydaGP.Validation;
using System.Collections.Generic;

namespace MoqaydaGP.ViewModel.Get
{
    public class User4ViewModel : AbstractValidatableObject
    {
        public string Id { get; set; }


        public List<UserProdOffersViewModel> UserProdOffersViewModels { get; set; }
    }
}
