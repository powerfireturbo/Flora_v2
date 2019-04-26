using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Flora.Models
{
    public class ResultsList : Dictionary<string, ObservableCollection<Plant>>
    {
        public int Total { get; private set; }

        public ResultsList(): base() { }

        public ResultsList(List<Plant> plants): base()
        {
            AddRange(plants);
        }

        public void AddRange(List<Plant> plants)
        {
            foreach(Plant p in plants)
            {
                if (!ContainsKey(p.Family))
                {
                    Add(p.Family, new ObservableCollection<Plant>());
                }
                this[p.Family].Add(p);
            }
            Total += plants.Count;
        }

        public bool Remove(Plant plant)
        {
            if (!ContainsKey(plant.Family))
            {
                return false;
            }

            foreach(var p in this){

            }
            return this[plant.Family].Remove(plant);
            
        }
    }
}
