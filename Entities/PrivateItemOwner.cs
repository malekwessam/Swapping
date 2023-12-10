using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MoqaydaGP.Entities
{
    public class PrivateItemOwner
    {
        public PrivateItemOwner()
        {

            
            PrivToSwap = new HashSet<PrivToSwap>();
           
            BarteredPriv = new HashSet<BarteredPriv>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? UserId { get; set; }
        public int? PrivateItemId { get; set; }

        public virtual User User { get; set; }
        public virtual PrivateItem PrivateItem { get; set; }
        public virtual ICollection<PrivToSwap> PrivToSwap { get; set; }
       
        public virtual ICollection<BarteredPriv> BarteredPriv { get; set; }
    }
}
