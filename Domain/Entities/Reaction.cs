namespace Domain.Entities

{
    public class Reaction
    {
        public int ReactionId { get; set; }
        public string ApplicationUserId { get; set; }
        public int PostId { get; set; }
        public string Text { get; set; }
        public string IconUri { get; set; }

        public virtual ApplicationUser ReactionOwner { get; set; }
        public virtual Post ReactionPost { get; set; }
    }
}
