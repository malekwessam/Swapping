using MoqaydaGP.Validation;
using System.ComponentModel.DataAnnotations;

namespace MoqaydaGP.ViewModel.Get
{
    public class ProdToSwapViewModel : AbstractValidatableObject
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        [MaxLength(200)]
        public string UserId { get; set; }
        public int ProductOwnerId { get; set; }
    }
}
