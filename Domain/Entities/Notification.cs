using Newtonsoft.Json;
using System;

namespace Domain.Entities
{
    [JsonObject]
    public class Notification
    {
        public int NotificationId { get; set; }
        public string NotifiedApplicationUserId { get; set; }
        public string Message { get; set; }
        public DateTime NotificationTime { get; set; }
        public bool WasRead { get; set; }

        public virtual ApplicationUser NotifiedApplicationUser { get; set; }
    }
}
