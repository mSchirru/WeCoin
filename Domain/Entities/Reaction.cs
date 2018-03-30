namespace Domain.Entities

{
    public class Reaction
    {
        public int ReactionId { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string Text { get; set; }
        public string IconUri { get; set; }

        public virtual User ReactionOwner { get; set; }
        public virtual Post ReactionPost { get; set; }
    }
}
