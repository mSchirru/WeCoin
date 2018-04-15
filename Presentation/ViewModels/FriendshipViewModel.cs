
namespace Presentation.ViewModels
{
    public class FriendshipViewModel
    {
        public string FromApplicationUserId { get; set; }
        
        public string ToApplicationUserId { get; set; }

        public bool Accepted { get; set; }

        public ApplicationUserViewModel ToApplicationUser { get; set; }
        public ApplicationUserViewModel FromApplicationUser { get; set; }
    }
}