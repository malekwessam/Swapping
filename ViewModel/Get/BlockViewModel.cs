using MoqaydaGP.Validation;

namespace MoqaydaGP.ViewModel.Get
{
    public class BlockViewModel : AbstractValidatableObject
    {
        public short Id { get; set; }
        public string BlockingUserId { get; set; }
        public string BlockedUserId { get; set; }
    }
}
