using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Kingdom
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("KingdomName")]
        public string KingdomName { get; set; }

        [Column("KingdomCapitol")]
        public string KingdomCapitol { get; set; }

        [Column("King")]
        public string King { get; set; }

        public virtual List<Group> Groups { get; set; }
    }
}