using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Friendship
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string FromApplicationUserId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ToApplicationUserId { get; set; }

        public bool Accepted { get; set; }

        public virtual ApplicationUser ToApplicationUser { get; set; }
        public virtual ApplicationUser FromApplicationUser { get; set; }
    }
}
