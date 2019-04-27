using Flora.Models;
using Flora.ViewModels.Location;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Flora.Views.Location
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultsPage : ContentPage
    {
        public static LocationSearchResultViewModel ViewModel;

        public ResultsPage()
        {
            InitializeComponent();
        }

        public ResultsPage(List<Plant> plants): this()
        {
            ViewModel = new LocationSearchResultViewModel(plants);
            BindingContext = ViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void PlantCell_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlantProfilePage((Plant)((TextCell)sender).BindingContext));
        }

        private async void Refine_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DynamicKeyPage(ViewModel));
        }
    }
}