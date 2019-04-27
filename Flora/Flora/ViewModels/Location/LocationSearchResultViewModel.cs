using Flora.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Flora.ViewModels.Location
{
    public class LocationSearchResultViewModel: INotifyPropertyChanged
    {
        private readonly List<Plant> baseList;

        private ObservableCollection<FamilyList> _resultsList;

        public event PropertyChangedEventHandler PropertyChanged;

        public string SelectedFirstHeading { get; set; }

        public string SelectedSecondHeading { get; set; }

        public bool DoneSelecting { get; set; }

        public DynamicKey Key { get; private set; }

        public ObservableCollection<Models.Attribute> SelectedAttributes { get; private set; }

        public ObservableCollection<Plant> CurrentList { get; private set; }

        public ObservableCollection<FamilyList> ResultsList
        {
            get
            {
                ReloadResultsList(CurrentList.ToList());
                return _resultsList;
            }
            set => _resultsList = value;
        }


        public LocationSearchResultViewModel() { }

        public LocationSearchResultViewModel(List<Plant> plants)
        {
            baseList = plants;
            CurrentList = new ObservableCollection<Plant>(plants);
            Key = new DynamicKey();
            Key.LoadKey(plants);
            SelectedAttributes = new ObservableCollection<Models.Attribute>();
            _resultsList = new ObservableCollection<FamilyList>();
        }

        private void ReloadResultsList(List<Plant> plants)
        {
            _resultsList.Clear();
            List<string> families = new List<string>();
            foreach (Plant p in plants)
            {
                if (!families.Contains(p.Family))
                {
                    families.Add(p.Family);
                }
            }
            foreach (string f in families)
            {
                FamilyList famList = new FamilyList(f, plants.FindAll(p => p.Family == f));
                _resultsList.Add(famList);
            }
            OnPropertyChanged("ResultsList");
        }

        public void SelectAttribute(Models.Attribute attribute)
        {
            SelectedAttributes.Add(attribute);
            ObservableCollection<Plant> newList = new ObservableCollection<Plant>(CurrentList);
            foreach (Plant p in CurrentList)
            {
                if (!p.Attributes.Contains(attribute))
                {
                    newList.Remove(p);
                }
            }
            CurrentList = newList;
            OnPropertyChanged("CurrentList");
            OnPropertyChanged("SelectedAttributes");
            ReloadKey();
        }

        public void ClearSelectedAttributes()
        {
            SelectedAttributes.Clear();
            CurrentList.Clear();
            foreach (Plant p in baseList)
            {
                CurrentList.Add(p);
            }
            OnPropertyChanged("CurrentList");
            OnPropertyChanged("SelectedAttributes");
            ReloadKey();
        }

        public void RemoveAttribute(Models.Attribute attribute)
        {
            SelectedAttributes.Remove(attribute);
            CurrentList.Clear();
            foreach (Plant p in baseList)
            {
                CurrentList.Add(p);
            }
            if (SelectedAttributes.Count > 0)
            {
                ObservableCollection<Plant> newList = new ObservableCollection<Plant>(CurrentList);
                foreach (Plant p in CurrentList)
                {
                    if (!p.Attributes.Contains(attribute))
                    {
                        newList.Remove(p);
                    }
                }
                CurrentList = newList;
            }
            OnPropertyChanged("CurrentList");
            OnPropertyChanged("SelectedAttributes");
            ReloadKey();
        }
        
        public void ReloadKey()
        {
            Key = new DynamicKey();
            Key.LoadKey(CurrentList.ToList(), SelectedAttributes);
            OnPropertyChanged("Key");
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
