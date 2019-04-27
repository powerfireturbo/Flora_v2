using Flora.Models;
using Flora.ViewModels.Location;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Flora.Views.Location
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LocationPage : ContentPage
	{
        public LocationViewModel ViewModel;
		public LocationPage ()
		{
            InitializeComponent ();
            ViewModel = new LocationViewModel();
            BindingContext = ViewModel;
		}

        private async void GPSSearch_Clicked(object sender, EventArgs e)
        {
            int radius = int.Parse(GPSRadius.Text);

            List<Plant> plants = await App.Plants.GetPlantsWithinRadiusAsync(radius);
            await Navigation.PushAsync(new ResultsPage(plants));

        }

        private async void RegionSearch_Clicked(object sender, EventArgs e)
        {
            List<Plant> plants;
            if (!ViewModel.CountyIsSet)
            {
                plants = await App.Plants.GetPlantsByStateAsync(ViewModel.State);
            }
            else
            {
                plants = await App.Plants.GetPlantsByCountyAsync(ViewModel.State, ViewModel.County);
            }
            await Navigation.PushAsync(new ResultsPage(plants));

        }

    }
}