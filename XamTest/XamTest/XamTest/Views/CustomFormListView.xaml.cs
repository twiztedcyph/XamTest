﻿using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamTest.Models;

namespace XamTest.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustomFormListView : ContentPage
	{
		public CustomFormListView ()
		{
			InitializeComponent ();
		}

        private void LvCustomForms_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void btnExit_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}