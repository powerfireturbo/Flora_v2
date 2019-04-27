using SQLite;

namespace Flora.Models
{
    [Table("PlantAttribute")]
    class PlantAttribute
    {
        public int PlantID { get; set; }

        public int AttributeID { get; set; }
    }
}
