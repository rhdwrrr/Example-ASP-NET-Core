using System.ComponentModel.DataAnnotations.Schema;

namespace OrigamiEdu.Models
{
    public class postComments
    {
        [Column(TypeName = "varchar(30)")]
        public string ID { get; set; }
        public string commentContent { get; set; }
        public string[] photo { get; set; } = new string[3];
        public AppUser actor { get; set; }
        public postKelas fkPost { get; set; }
        public bool isDeleted { get; set; }

    }
}