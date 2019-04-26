using Flora.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Flora.ViewModels.Location
{
    public class DynamicKeyPageViewModel: INotifyPropertyChanged
    {
        private readonly List<Plant> baseList;

        public event PropertyChangedEventHandler PropertyChanged;

        public string SelectedFirstHeading { get; set; }
        public string SelectedSecondHeading { get; set; }

        public DynamicKey Key { get; private set; }

        public ObservableCollection<Models.Attribute> SelectedAttributes { get; private set; }

        public ObservableCollection<Plant> CurrentList { get; private set; }


        public bool DoneSelecting { get; set; }

        public DynamicKeyPageViewModel()
        {

        }

        public DynamicKeyPageViewModel(List<Plant> plants)
        {
            baseList = plants;
            CurrentList = new ObservableCollection<Plant>(plants);
            Key = new DynamicKey();
            Key.LoadKey(plants);
            SelectedAttributes = new ObservableCollection<Models.Attribute>();
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
