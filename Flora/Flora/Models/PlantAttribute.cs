using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
