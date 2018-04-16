using System;
using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels
{
    public class PostViewModel
    {
        public int PostId { get; set; }
        public string Content { get; set; }
        public string ImageUri { get; set; }
        public DateTime PostTime { get; set; }
    }
}