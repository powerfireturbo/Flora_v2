using Flora.ViewModels.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Flora.Views.Location
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SecondHeadingPage : ContentPage
	{
        public DynamicKeyPageViewModel KeyViewModel { get; set; }
        public string FirstHeading { get; set; }
		public SecondHeadingPage (DynamicKeyPageViewModel key)
		{
			InitializeComponent ();
            KeyViewModel = key;
            FirstHeading = KeyViewModel.SelectedFirstHeading;

        }

        protected async override void OnAppearing()
        {
            if (KeyViewModel.DoneSelecting)
            {
                TheList.ItemsSource = null;
                await Navigation.PopAsync();
            }
            else
            {
                TheList.ItemsSource = KeyViewModel.Key[FirstHeading].Keys;
            }
            base.OnAppearing();

        }

        private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            (sender as ListView).SelectedItem = null;

            if (args.SelectedItem != null)
            {
                KeyViewModel.SelectedSecondHeading = (string)args.SelectedItem;
                await Navigation.PushAsync(new AttributeSelectionPage(KeyViewModel));
            }
        }
    }
}