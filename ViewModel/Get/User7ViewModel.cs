using MoqaydaGP.Validation;
using System.Collections.Generic;

namespace MoqaydaGP.ViewModel.Get
{
    public class User7ViewModel : AbstractValidatableObject
    {
        public string Id { get; set; }


        public List<UserBarteredProductViewModel> UserBarteredProductViewModels { get; set; }
    }
}
