using System;
using System.Collections.Generic;

namespace Presentation.ViewModels
{
    public class PostViewModel
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public string ImageUri { get; set; }
        public DateTime PostTime { get; set; }

        public ApplicationUserViewModel Author { get; set; }
        public ICollection<ReactionViewModel> Reactions { get; set; }
    }
}