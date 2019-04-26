using Flora.Data;
using Flora.Models;
using Flora.ViewModels.Location;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //await Navigation.PushAsync(new DynamicKeyPage(plants));
            await Navigation.PushAsync(new ResultsPage(plants));

        }

        private async void RegionSearch_Clicked(object sender, EventArgs e)
        {
            if (ViewModel.County != null)
            {
                //await Navigation.PushAsync(new DynamicKeyPage(await App.Plants.GetPlantsByStateAsync(ViewModel.State)));
                await Navigation.PushAsync(new ResultsPage(await App.Plants.GetPlantsByStateAsync(ViewModel.State)));

            }
            else
            {
                //await Navigation.PushAsync(new DynamicKeyPage(await App.Plants.GetPlantsByCountyAsync(ViewModel.State, ViewModel.County)));
                await Navigation.PushAsync(new ResultsPage(await App.Plants.GetPlantsByCountyAsync(ViewModel.State, ViewModel.County)));

            }
        }
    }
}