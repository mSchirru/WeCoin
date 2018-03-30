using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class User
    {
        public User()
        {
            UserName = new Name();
        }

        [Key]
        public int Gid { get; set; }
        public Name UserName { get; set; }
        [Index(IsUnique = true)]
        [MaxLength(100)]
        public string UserEmail { get; set; }
        
        public virtual ICollection<Friendship> Friendships { get; set; }
        public virtual ICollection<Friendship> Friendships1 { get; set; }
        public virtual ICollection<Wallet> Wallets { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Reaction> Reactions { get; set; }
    }
}
