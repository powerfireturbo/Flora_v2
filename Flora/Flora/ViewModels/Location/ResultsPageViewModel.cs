using Flora.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Flora.ViewModels.Location
{
    class ResultsPageViewModel : INotifyPropertyChanged
    {
        public List<FamilyList> ResultsList { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ResultsPageViewModel(List<Plant> plants)
        {

        }

        private void AddList(List<Plant> plants)
        {
            List<string> families = new List<string>();
            foreach(Plant p in plants)
            {
                if (!families.Contains(p.Family))
                {
                    families.Add(p.Family);
                }
            }
            foreach(string f in families)
            {
                FamilyList famList = new FamilyList(f, plants.FindAll(p => p.Family == f));
            }
            OnPropertyChanged("ResultsList");
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
