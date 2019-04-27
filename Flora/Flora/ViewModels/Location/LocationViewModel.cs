using System.ComponentModel;

namespace Flora.ViewModels.Location
{
    public class LocationViewModel: INotifyPropertyChanged
    {
        private string state = "indiana";
        private string county;
        public bool StateIsSet { get; set; } = true;
        public bool CountyIsSet { get; set; } = false;
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
                    CountyIsSet = true;
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
