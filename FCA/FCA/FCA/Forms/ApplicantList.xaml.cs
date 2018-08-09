using FCA.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms.Xaml;

namespace FCA.Forms
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ApplicantList : FCAContentPage
	{
        public ApplicantList()
		{
			InitializeComponent ();
		}

        private void FormView_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {

        }

        private void edSearchBarName_SearchButtonPressed(object sender, System.EventArgs e)
        {

        }

        private void edSearchBarName_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {

        }

        private void ToolbarItem_Clicked(object sender, System.EventArgs e)
        {

        }
    }
}