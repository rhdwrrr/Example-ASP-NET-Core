using System;
using System.ComponentModel.DataAnnotations;

namespace OrigamiEdu.Models
{
    public class loginLog
    {
        [Key]
        public string loginID { get; set; }

        public string username { get; set; }
        public string ip { get; set; }
        public DateTime timestamp { get; set; }

    }
}