using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Flora.Models
{
    [Table("Plants")]
    public class Plant : IEquatable<Plant>
    {
        [PrimaryKey, AutoIncrement]
        public int PlantID { get; set; }

        [Indexed]
        public string ScientificName { get; set; }

        [Indexed]
        public string Family { get; set; }

        [Indexed]
        public string Genus { get; set; }

        [Ignore]
        public List<Attribute> Attributes { get; set; }

        public bool Equals(Plant other)
        {
            return this.ScientificName == other.ScientificName;
        }
    }
}
