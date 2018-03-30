using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Post
    {
        public Post() {}

        public Post(string content, string imageUri, User author)
        {
            PostTime = DateTime.Now;
            Content = content;
            ImageUri = imageUri;
            Author = author;
        }

        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public string ImageUri { get; set; }
        public DateTime PostTime { get; set; }

        public virtual User Author { get; set; }
        public virtual ICollection<Reaction> Reactions { get; set; }
    }
}
