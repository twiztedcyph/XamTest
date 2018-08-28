using FCA.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FCA.Forms
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ApplicantList : FCAContentPage
	{
        ObservableCollection<DBApplicant> applicantList = new ObservableCollection<DBApplicant>();
        public ApplicantList()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetApplicants();
            FormView.ItemsSource = applicantList;
        }

        private void GetApplicants()
        {
            List<DBApplicant> applicants;
            if (string.IsNullOrWhiteSpace(edSearchBarName.Text))
                applicants = Task.Run(() => App.DB.GetApplicants()).Result;
            else
                applicants = Task.Run(() => App.DB.SearchApplicants(edSearchBarName.Text)).Result;
            applicantList = new ObservableCollection<DBApplicant>(applicants);
        }

        private void FormView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private void edSearchBarName_SearchButtonPressed(object sender, System.EventArgs e)
        {
            GetApplicants();
        }

        private void edSearchBarName_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetApplicants();
        }

        private async void Import_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ApplicantImport());
            GetApplicants();
        }
    }
}