using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Presentation.ViewModels
{
    public class ApplicationUserViewModel
    {
        public string Id { get; set; }
        [Required]
        [DisplayName("Nome")]
        public string Name { get; set; }
        [Required]
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
        [DataType(DataType.Date)]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Digite uma senha!")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{6,20}$", ErrorMessage = "Requisitos de senha: mínimo de 6 letras; 1 letra maiúscula; 1 número; 1 caractere especial")]
        [DisplayName("Senha")]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Senhas diferentes")]
        [DisplayName("Confirmar senha")]
        public string ConfirmPassword { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [DisplayName("Endereço da carteira virtual")]
        [RegularExpression("4[0-9AB][123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz]{93}", ErrorMessage = "Endereço de carteira Monero inválido!")]
        public string WalletAddress { get; set; }
        [DisplayName("País")]
        public string Country { get; set; }
        [DisplayName("Estado")]
        public string State { get; set; }

        public ICollection<FriendshipViewModel> Friends { get; set; }
        public ICollection<NotificationViewModel> Notifications { get; set; }
        public ICollection<PostViewModel> Posts { get; set; }
        //public virtual ICollection<ReactionViewModel> Reactions { get; set; }
    }
}