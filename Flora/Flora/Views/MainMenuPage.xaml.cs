using Flora.Data;
using Flora.Views.DirectLookup;
using Flora.Views.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Flora.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainMenuPage : ContentPage
	{
		public MainMenuPage ()
		{
			InitializeComponent ();
		}


        private async void LocationButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LocationPage());
        }

        private async void DirectLookupButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FamilyPage());
        }
    }
}