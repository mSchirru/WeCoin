using System;

namespace Presentation.ViewModels
{
    public class NotificationViewModel
    {
        public int NotificationId { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public DateTime NotificationTime { get; set; }
        public bool WasRead { get; set; }

        public ApplicationUserViewModel NotifiedUser { get; set; }
    }
}