using MoqaydaGP.Validation;
using System.Collections.Generic;

namespace MoqaydaGP.ViewModel.Get
{
    public class User5ViewModel : AbstractValidatableObject
    {
        public string Id { get; set; }


        public List<UserPrivateItemViewModel> UserPrivateItemViewModels { get; set; }
    }
}
