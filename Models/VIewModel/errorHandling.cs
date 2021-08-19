using System.ComponentModel.DataAnnotations.Schema;

namespace OrigamiEdu.Models
{
    public class errorHandling
    {
        [NotMapped]
        public string timeStamp { get; set; }
        [NotMapped]
        public string errorCode { get; set; }
        [NotMapped]
        public string errorMessage { get; set; }
        public errorHandling(string _tS, string _errC, string _errM)
        {
            timeStamp = _tS; errorCode = _errC; errorMessage = _errM;
        }
    }
}