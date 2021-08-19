using System;

namespace OrigamiEdu.Models
{
    public class classParticipant
    {
        public Guid ID { get; set; }
        public kelas fkKelas { get; set; }
        public DateTime timestamp { get; set; }
        public AppUser account { get; set; }
        public bool isBannedToPost { get; init; }
        public DateTime bannedUntil { get; set; }
        public bool isCreator { get; set; }
    }
}