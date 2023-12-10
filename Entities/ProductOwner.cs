using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MoqaydaGP.Entities
{
    public class ProductOwner
    {
        public ProductOwner()
        {

            ProdToSwap = new HashSet<ProdToSwap>();
            PrivateSwap = new HashSet<PrivateSwap>();
            BarteredProduct = new HashSet<BarteredProduct>();
            BarteredPrivateItem = new HashSet<BarteredPrivateItem>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? UserId { get; set; }
        public int? ProductId { get; set; }

        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<ProdToSwap> ProdToSwap { get; set; }
        public virtual ICollection<PrivateSwap> PrivateSwap { get; set; }
        public virtual ICollection<BarteredProduct> BarteredProduct { get; set; }
        public virtual ICollection<BarteredPrivateItem> BarteredPrivateItem { get; set; }
    }
}
