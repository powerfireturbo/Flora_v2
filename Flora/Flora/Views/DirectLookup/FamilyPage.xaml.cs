using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Flora.Views.DirectLookup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FamilyPage : ContentPage
	{
        List<string> Families { get; set; }
		public FamilyPage ()
		{
			InitializeComponent ();
		}

        protected async override void OnAppearing()
        {
            FamilyList.ItemsSource = await App.Plants.GetFamiliesAsync();
            base.OnAppearing();
        }

        private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            (sender as ListView).SelectedItem = null;

            if (args.SelectedItem != null)
            {
                string selectedItem = (string)args.SelectedItem;
                await Navigation.PushAsync(new GenusPage(selectedItem));
            }
        }
    }
}