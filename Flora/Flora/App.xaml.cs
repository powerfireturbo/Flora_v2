using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Flora.Data;
using Flora.Views;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Net.Http;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Flora
{
    public partial class App : Application
    {
        static IPlantService plants;
        private static string dbPath;
        public static IPlantService Plants
        {
            get
            {
                if (plants == null)
                {
                    plants = new PlantService(new ImageService(), new GeoService(@"https://search.idigbio.org/v2/search/records/"), new FloraDB(dbPath));
                }
                return plants;
            }
        }

        
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainMenuPage());
        }

        public App(string path) : this()
        {
            dbPath = path;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
