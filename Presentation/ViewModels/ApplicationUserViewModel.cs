using System;
using Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels
{
    public class ApplicationUserViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string EmailConfirmed { get; set; }
        public string UserName { get; set; }
        public string ImgUrl { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberConfirmed { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string WalletAddress { get; set; }

        //public virtual ICollection<FriendshipViewModel> Friendships { get; set; }
        public ICollection<FriendshipViewModel> Friends { get; set; }
        //public virtual ICollection<WalletViewModel> Wallets { get; set; }
        public ICollection<NotificationViewModel> Notifications { get; set; }
        public ICollection<PostViewModel> Posts { get; set; }
        //public virtual ICollection<ReactionViewModel> Reactions { get; set; }
    }
}