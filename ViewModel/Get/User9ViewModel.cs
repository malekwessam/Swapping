using MoqaydaGP.Validation;
using System.Collections.Generic;

namespace MoqaydaGP.ViewModel.Get
{
    public class User9ViewModel : AbstractValidatableObject
    {
        public string Id { get; set; }

        public List<UserProductOwnersViewModel> UserProductOwnersViewModels { get; set; }
    }
}
