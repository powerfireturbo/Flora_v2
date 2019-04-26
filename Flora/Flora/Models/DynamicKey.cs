using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Linq;
using System.Threading.Tasks;
using Flora.Models;
using System.Collections.ObjectModel;

namespace Flora.Models
{
    
    public class DynamicKey: Dictionary<string, Dictionary<string, ObservableCollection<Attribute>>>
    {
        public DynamicKey() { }

        public bool IsLoaded { get; set; } = false;

        public void LoadKey(List<Plant> plants, ObservableCollection<Models.Attribute> exclude = null)
        {
            IsLoaded = false;
            ObservableCollection<Models.Attribute> toEclude = exclude ?? new ObservableCollection<Attribute>();
            foreach (Plant p in plants)
            {
                foreach (Attribute a in p.Attributes)
                {
                    if (!toEclude.Contains(a))
                    {
                        if (!ContainsKey(a.FirstHeading))
                        {
                            Add(a.FirstHeading, new Dictionary<string, ObservableCollection<Attribute>>());
                        }
                        if (!this[a.FirstHeading].ContainsKey(a.SecondHeading))
                        {
                            this[a.FirstHeading].Add(a.SecondHeading, new ObservableCollection<Attribute>());
                        }
                        if (!this[a.FirstHeading][a.SecondHeading].Contains(a))
                        {
                            this[a.FirstHeading][a.SecondHeading].Add(a);
                        }
                    }
                }
            }

            IsLoaded = true;
        }
    }
}
