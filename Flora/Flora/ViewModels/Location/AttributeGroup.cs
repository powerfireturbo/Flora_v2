using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Flora.Models;

namespace Flora.ViewModels.Location
{
    class FirstAttributeGroup : ObservableCollection<SecondAttributeGroup>, INotifyPropertyChanged, IEquatable<FirstAttributeGroup>
    {
        public string FirstGroupName { get; private set; }
        private bool _expanded;
        public bool Expanded
        {
            get { return _expanded; }
            set
            {
                if (_expanded != value)
                {
                    _expanded = value;
                    OnPropertyChanged("Expanded");
                }
            }
        }

        public FirstAttributeGroup(string name, bool expanded = true)
        {
            FirstGroupName = name;
            Expanded = expanded;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool Equals(FirstAttributeGroup other)
        {
            return FirstGroupName == other.FirstGroupName;
        }
    }

    class SecondAttributeGroup : List<Models.Attribute>, IEquatable<SecondAttributeGroup>
    {
        public string SecondGroupName { get; private set; }
        
        public SecondAttributeGroup(string name)
        {
            SecondGroupName = name;
        }

        public bool Equals(SecondAttributeGroup other)
        {
            return SecondGroupName == other.SecondGroupName;
        }
    }
}
