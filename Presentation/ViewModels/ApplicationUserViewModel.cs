﻿using Domain.Entities;
using System.Collections.Generic;

namespace Presentation.ViewModels
{
    public class ApplicationUserViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string EmailConfirmed { get; set; }
        public string UserName { get; set; }
        //public bool TwoFactorEnabled { get; set; }
        //public string PhoneNumber { get; set; }
        //public string PhoneNumberConfirmed { get; set; }

        public virtual ICollection<Friendship> Friends { get; set; }
        //public virtual ICollection<WalletViewModel> Wallets { get; set; }
        //public virtual ICollection<NotificationViewModel> Notifications { get; set; }
        public virtual ICollection<PostViewModel> Posts { get; set; }
        //public virtual ICollection<ReactionViewModel> Reactions { get; set; }
    }
}