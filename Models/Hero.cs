using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public class Hero
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("HeroName")]
        public string HeroName { get; set; }

        [Column("HeroClass")]
        public string HeroClass { get; set; }

        [Column("HeroOrder")]
        public int HeroOrder { get; set; }

        [JsonIgnore]
        public Group Group { get; set; }

    }
}