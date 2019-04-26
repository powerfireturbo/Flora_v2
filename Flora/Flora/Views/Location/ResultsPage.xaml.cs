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
        public ResultsPage()
        {
            InitializeComponent();
        }

        public ResultsPage(List<Plant> plants): this()
        {
            BindingContext = new ResultsPageViewModel(plants);
        }

        private async void PlantCell_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlantProfilePage((Plant)((TextCell)sender).BindingContext));
        }
    }
}