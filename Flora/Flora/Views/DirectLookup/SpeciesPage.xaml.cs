using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Flora.Views.DirectLookup
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SpeciesPage : ContentPage
	{
        private string _family;
        private string _genus;
        public SpeciesPage (string family, string genus)
		{
            _family = family;
            _genus = genus;
			InitializeComponent ();
		}
        public SpeciesPage() {
			InitializeComponent ();
        }

        protected async override void OnAppearing()
        {
            Title =  _family + " > " + _genus;
            SpeciesList.ItemsSource = await App.Plants.GetSpeciesAsync(_genus);
            base.OnAppearing();
        }

        private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            (sender as ListView).SelectedItem = null;

            if (args.SelectedItem != null)
            {
                string selectedItem = (string)args.SelectedItem;
                Debug.WriteLine(selectedItem + " Was selected");
                
                await Navigation.PushAsync(new PlantProfilePage());
            }
        }
    }
}