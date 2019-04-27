using Flora.Models;
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
    public partial class ResultsPage : ContentPage
    {
        public static ResultsPageViewModel ViewModel;
        public static DynamicKeyPageViewModel KeyVM;

        public ResultsPage()
        {
            InitializeComponent();
        }

        public ResultsPage(List<Plant> plants): this()
        {
            ViewModel = new ResultsPageViewModel();
            KeyVM = new DynamicKeyPageViewModel(plants);
            BindingContext = ViewModel;
        }

        protected override void OnAppearing()
        {
            ViewModel.Plants = KeyVM.CurrentList.ToList();
            base.OnAppearing();
        }

        private async void PlantCell_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlantProfilePage((Plant)((TextCell)sender).BindingContext));
        }

        private async void Refine_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DynamicKeyPage(KeyVM));
        }
    }
}