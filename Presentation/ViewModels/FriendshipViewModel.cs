using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities;

namespace Presentation.ViewModels
{
    public class FriendshipViewModel
    {
        public string FromApplicationUserId { get; set; }
        
        public string ToApplicationUserId { get; set; }

        public bool Accepted { get; set; }

        public virtual ApplicationUser ToApplicationUser { get; set; }
        public virtual ApplicationUser FromApplicationUser { get; set; }
    }
}