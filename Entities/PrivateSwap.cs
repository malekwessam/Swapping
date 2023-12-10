using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MoqaydaGP.Entities
{
    public class PrivateSwap
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? UserId { get; set; }
        public int? PrivateItemId { get; set; }
        public int? ProductOwnerId { get; set; }

        public virtual User User { get; set; }
        public virtual PrivateItem PrivateItem { get; set; }
        public virtual ProductOwner ProductOwner { get; set; }
    }
}
