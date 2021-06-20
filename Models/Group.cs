using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{

    public class Group
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("GroupName")]
        public string GroupName { get; set; }

        [Column("GroupSize")]
        public int GroupSize { get; set; }

        [Column("GroupType")]
        public string GroupType { get; set; }

        [Column("Location")]
        public string Location { get; set; }

        [JsonIgnore]
        public Kingdom Kingdom { get; set; }

        public virtual List<Hero> Heroes { get; set; }
    }
}