using Flora.ViewModels.Location;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Flora.Views.Location
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViewSelectedAttributesPage : ContentPage
	{
        public LocationSearchResultViewModel KeyViewModel { get; private set; }
		public ViewSelectedAttributesPage ()
		{
			InitializeComponent ();
		}

        public ViewSelectedAttributesPage(LocationSearchResultViewModel key): this()
        {
            KeyViewModel = key;
            BindingContext = KeyViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void ClearSelectedAttributes_Clicked(object sender, EventArgs e)
        {
            KeyViewModel.ClearSelectedAttributes();
            await Navigation.PopAsync();
        }

        private async void DoneEditing_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }


        private void RemoveAttribute_Clicked(object sender, EventArgs e)
        {
            KeyViewModel.RemoveAttribute(((Button)sender).BindingContext as Models.Attribute);

        }
    }
}