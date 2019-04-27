using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Flora.ViewModels.Location;

namespace Flora.Views.Location
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AttributeSelectionPage : ContentPage
	{
        public LocationSearchResultViewModel KeyViewModel { get; set; }

        public string FirstHeading { get; set; }
        public string SecondHeading { get; set; }
        public AttributeSelectionPage (LocationSearchResultViewModel key)
		{
			InitializeComponent ();
            KeyViewModel = key;
        }

        protected override void OnAppearing()
        {
            FirstHeading = KeyViewModel.SelectedFirstHeading;
            SecondHeading = KeyViewModel.SelectedSecondHeading;
            TheList.ItemsSource = KeyViewModel.Key[FirstHeading][SecondHeading];

            base.OnAppearing();

        }

        private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            (sender as ListView).SelectedItem = null;

            if (args.SelectedItem != null)
            {
                TheList.ItemsSource = null;
                KeyViewModel.SelectAttribute(args.SelectedItem as Models.Attribute);
                KeyViewModel.DoneSelecting = true;
                await Navigation.PopAsync();
            }
        }
    }
}