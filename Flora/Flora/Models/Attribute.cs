using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Flora.Models
{
    [Table("Attributes")]
    public class Attribute : IEquatable<Attribute>
    {
        [PrimaryKey, AutoIncrement]
        public int AttributeID { get; set; }

        [Indexed]
        public string Name { get; set; }

        public string Description { get; set; }

        [Indexed]
        public string FirstHeading { get; set; }

        [Indexed]
        public string SecondHeading { get; set; }

        [Ignore]
        public string Color { get; set; }

        public bool Equals(Attribute other)
        {
            return Name + SecondHeading == other.Name + other.SecondHeading;
        }

    }
}
