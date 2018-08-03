using Xamarin.Forms;
using XamTest.Views;

namespace XamTest
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private void btnForms_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new CustomFormListView()));
        }

        private void btnLearners_Clicked(object sender, System.EventArgs e)
        {

        }

        private void btnApplicants_Clicked(object sender, System.EventArgs e)
        {

        }

        private void btnCompanies_Clicked(object sender, System.EventArgs e)
        {

        }

        private void btnTools_Clicked(object sender, System.EventArgs e)
        {

        }

        private void btnDebugOptions_Clicked(object sender, System.EventArgs e)
        {

        }

        private void btnSync_Clicked(object sender, System.EventArgs e)
        {

        }

        private void btnHelp_Clicked(object sender, System.EventArgs e)
        {

        }
    }
}
