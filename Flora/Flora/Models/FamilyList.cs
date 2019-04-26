using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Flora.Models
{
    public class FamilyList: List<Plant>
    {
        public string FamilyName { get; set; }
        public List<Plant> Plants => this;

        public FamilyList(string family, List<Plant> plants)
        {
            FamilyName = family;
            AddRange(plants);
        }
    }
}
