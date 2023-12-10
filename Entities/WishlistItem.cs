using System.ComponentModel.DataAnnotations.Schema;

namespace MoqaydaGP.Entities
{
    public class WishlistItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int? ProductId { get; set; }
        public string? UserId { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
