using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MoqaydaGP.Entities
{
    public class User
    {
        public User()
        {
            Product = new HashSet<Product>();
            WishlistItem = new HashSet<WishlistItem>();
            ProductOwner = new HashSet<ProductOwner>();
            ProdToSwap = new HashSet<ProdToSwap>();
            PrivateItem = new HashSet<PrivateItem>();
            PrivateSwap = new HashSet<PrivateSwap>();
            BarteredProduct = new HashSet<BarteredProduct>();
            BarteredPrivateItem = new HashSet<BarteredPrivateItem>();
            PrivateItemOwner = new HashSet<PrivateItemOwner>();
            PrivToSwap = new HashSet<PrivToSwap>();
            BarteredPriv = new HashSet<BarteredPriv>();
        }
        [Key]
        [Required]

        public string Id { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required]
        public string phoneNumber { get; set; }
        [Required]
        public string country { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        
        public string email { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string PathImage { get; set; }


        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<WishlistItem> WishlistItem { get; set; }
        public virtual ICollection<ProductOwner> ProductOwner { get; set; }
        public virtual ICollection<ProdToSwap> ProdToSwap { get; set; }
        public virtual ICollection<PrivateItem> PrivateItem { get; set; }
        public virtual ICollection<PrivateSwap> PrivateSwap { get; set; }
        public virtual ICollection<BarteredProduct> BarteredProduct { get; set; }
        public virtual ICollection<BarteredPrivateItem> BarteredPrivateItem { get; set; }
        public virtual ICollection<PrivateItemOwner> PrivateItemOwner { get; set; }
        public virtual ICollection<PrivToSwap> PrivToSwap { get; set; }
        public virtual ICollection<BarteredPriv> BarteredPriv { get; set; }
    }
}
