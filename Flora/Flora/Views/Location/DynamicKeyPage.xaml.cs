﻿using Flora.Models;
using Flora.ViewModels.Location;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Flora.Views.Location
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DynamicKeyPage : ContentPage
	{
        public static DynamicKeyPageViewModel KeyViewModel;

        public DynamicKeyPage ()
		{
			InitializeComponent ();
		}


        public DynamicKeyPage(List<Plant> plants) : this()
        {
            KeyViewModel = new DynamicKeyPageViewModel(plants);
            BindingContext = KeyViewModel;
        }

        protected override void OnAppearing()
        {
            KeyViewModel.DoneSelecting = false;
            Title = "Dynamic Key";
            base.OnAppearing();
        }

        private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            (sender as ListView).SelectedItem = null;
            if (args.SelectedItem != null)
            {
                KeyViewModel.SelectedFirstHeading = (string)args.SelectedItem;
                await Navigation.PushAsync(new SecondHeadingPage(KeyViewModel));
            }
        }

        private async void SelectedAttributesButton_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ViewSelectedAttributesPage(KeyViewModel)); 
        }

        private void Results_Clicked(object sender, System.EventArgs e)
        {

        }
    }
}