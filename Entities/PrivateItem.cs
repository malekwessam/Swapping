using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MoqaydaGP.Entities
{
    public class PrivateItem
    {
        public PrivateItem()
        {

            
            PrivateSwap = new HashSet<PrivateSwap>();
            BarteredPrivateItem = new HashSet<BarteredPrivateItem>();
            PrivateItemOwner = new HashSet<PrivateItemOwner>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? UserId { get; set; }
        [Required]
        [MinLength(3), MaxLength(250)]
        [Column(TypeName = "nvarchar(250)")]
        public string PrivateItemeName { get; set; }

        [MinLength(1), MaxLength(8000)]
        [Column(TypeName = "nvarchar(max)")]
        public string PrivateItemDescription { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string PathImage { get; set; }

        public virtual User User { get; set; }
      
        public virtual ICollection<PrivateSwap> PrivateSwap { get; set; }
        public virtual ICollection<BarteredPrivateItem> BarteredPrivateItem { get; set; }
        public virtual ICollection<PrivateItemOwner> PrivateItemOwner { get; set; }
    }
}
