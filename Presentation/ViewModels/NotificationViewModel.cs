using System;

namespace Presentation.ViewModels
{
    public class NotificationViewModel
    {
        public int NotificationId { get; set; }
        public string Message { get; set; }
        public DateTime NotificationTime { get; set; }
        public bool WasRead { get; set; }

        public ApplicationUserViewModel NotificationIssuer { get; set; }
    }
}