using Flora.Models;
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
	public partial class PlantProfilePage : ContentPage
	{
		public PlantProfilePage ()
		{
			InitializeComponent ();
		}

        public PlantProfilePage(Plant plant): this()
        {
            BindingContext = plant;
        }
    }
}