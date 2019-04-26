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
        public LocationViewModel ViewModel { get; }
		public LocationPage ()
		{
            InitializeComponent ();
		}

        private async void GPSSearch_Clicked(object sender, EventArgs e)
        {
            int radius = int.Parse(GPSRadius.Text);
            Debug.WriteLine("Radius = " + radius);

            List<Plant> ps = await App.Plants.GetPlantsWithinRadiusAsync(radius);
            Debug.WriteLine("Made it past List<Plant> ps. Count = " + ps.Count);
            await Navigation.PushAsync(new DynamicKeyPage(ps));
        }

        private async void RegionSearch_Clicked(object sender, EventArgs e)
        {
            if (ViewModel.County != null)
            {
                await Navigation.PushAsync(new DynamicKeyPage(await App.Plants.GetPlantsByStateAsync(ViewModel.State)));
            }
            else
            {
                await Navigation.PushAsync(new DynamicKeyPage(await App.Plants.GetPlantsByCountyAsync(ViewModel.State, ViewModel.County)));
            }
        }
    }
}