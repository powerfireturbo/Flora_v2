using Flora.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Flora.ViewModels.Location
{
    public class ResultsPageViewModel : INotifyPropertyChanged
    {
        private List<Plant> _plants;
        public List<Plant> Plants {
            get => _plants;
            set {
                ReloadList(value);
                _plants = value;
                OnPropertyChanged("Plants");
            } }

        public ObservableCollection<FamilyList> ResultsList { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ResultsPageViewModel()
        {
            ResultsList = new ObservableCollection<FamilyList>();
        }

        public ResultsPageViewModel(List<Plant> plants): this()
        {
            Plants = plants;
        }

        private void ReloadList(List<Plant> plants)
        {
            ResultsList.Clear();
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
                ResultsList.Add(famList);
            }
            OnPropertyChanged("ResultsList");
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
