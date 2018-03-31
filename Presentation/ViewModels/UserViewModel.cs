using Domain.Entities;
using System.Collections.Generic;

namespace Presentation.ViewModels
{
    public class UserViewModel
    {
        public int Gid { get; set; }
        public string FirstName { get; set; }
        public string SecName { get; set; }

        public virtual ICollection<Friendship> Friendships { get; set; }
        public virtual ICollection<WalletViewModel> Wallets { get; set; }
        public virtual ICollection<NotificationViewModel> Notifications { get; set; }
        public virtual ICollection<PostViewModel> Posts { get; set; }
        public virtual ICollection<ReactionViewModel> Reactions { get; set; }
    }
}