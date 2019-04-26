using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Flora.ViewModels.Location
{
    public class LocationViewModel: INotifyPropertyChanged
    {
        private string state = "indiana";
        private string county;
        public bool StateIsSet { get; private set; } = true;
        public string State
        {
            get => state;
            set
            {
                state = value.ToLower();
                StateIsSet = true;
                OnPropertyChanged("State");
            }
        }
        public string County
        {
            get => county;
            set
            {
                if (StateIsSet)
                {
                    county = value.ToLower();
                    OnPropertyChanged("County");
                }

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
