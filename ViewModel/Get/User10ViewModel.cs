using MoqaydaGP.Validation;
using System.Collections.Generic;

namespace MoqaydaGP.ViewModel.Get
{
    public class User10ViewModel : AbstractValidatableObject
    {
        public string Id { get; set; }

        public List<UserPrivOwnerViewModel> UserPrivOwnerViewModels { get; set; }
    }
}
