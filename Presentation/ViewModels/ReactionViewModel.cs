namespace Presentation.ViewModels
{
    public class ReactionViewModel
    {
        public int ReactionId { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string Text { get; set; }
        public string IconUri { get; set; }

        public ApplicationUserViewModel ReactionOwner { get; set; }
        public PostViewModel ReactionPost { get; set; }
    }
}