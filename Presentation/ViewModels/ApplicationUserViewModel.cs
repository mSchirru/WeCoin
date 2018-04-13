using System;
using Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Presentation.ViewModels
{
    public class ApplicationUserViewModel
    {
        public string Id { get; set; }
        [DisplayName("Nome")]
        public string Name { get; set; }
        public string Email { get; set; }
        public string EmailConfirmed { get; set; }
        public string UserName { get; set; }
        [DisplayName("Avatar")]
        public string ImgUrl { get; set; }
        public bool TwoFactorEnabled { get; set; }
        [DisplayName("Telefone")]
        public string PhoneNumber { get; set; }
        public string PhoneNumberConfirmed { get; set; }
        [Display(Name = "Data de nascimento")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        [DisplayName("Endereço da carteira virtual")]
        public string WalletAddress { get; set; }

        public ICollection<FriendshipViewModel> Friends { get; set; }
        public ICollection<NotificationViewModel> Notifications { get; set; }
        public ICollection<PostViewModel> Posts { get; set; }
        //public virtual ICollection<ReactionViewModel> Reactions { get; set; }
    }
}