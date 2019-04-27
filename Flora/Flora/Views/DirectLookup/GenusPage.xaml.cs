using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Flora.Views.DirectLookup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GenusPage : ContentPage
	{
        private static string _family { get; set; }
 		public GenusPage (string family)
		{
            _family = family;
			InitializeComponent ();
		}

        protected async override void OnAppearing()
        {
            Title = _family;
            GenusList.ItemsSource = await App.Plants.GetGeneraAsync(_family);
            base.OnAppearing();
        }


        private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            (sender as ListView).SelectedItem = null;

            if (args.SelectedItem != null)
            {
                string selectedItem = (string)args.SelectedItem;
                await Navigation.PushAsync(new SpeciesPage(_family, selectedItem));
            }
        }
    }
}