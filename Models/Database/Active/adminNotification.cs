using System;

namespace OrigamiEdu.Models
{
    public class adminNotification
    {
        // public Guid ID { get; set; }
        public AppUser admin { get; set; }
        public string type { get; set; }
        public string info { get; set; }
        public string link { get; set; }
        public DateTime timestamp { get; set; }
        public bool isSeen { get; set; }
    }
}