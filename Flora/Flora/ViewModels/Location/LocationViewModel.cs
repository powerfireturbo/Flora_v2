using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Flora.ViewModels.Location
{
    public class LocationViewModel
    {
        private string state = "indiana";
        private string county;
        public bool StateIsSet { get; private set; } = true;
        public string State
        {
            get => county;
            set
            {
                state = value.ToLower();
                StateIsSet = true;
            }
        }
        public string County
        {
            get => county;
            set
            {
                if (StateIsSet)
                    county = value.ToLower();
            }
        }

    }
}
