using FCA.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FCA.Forms
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ApplicantList : FCAContentPage
	{
        ObservableCollection<DBApplicant> Applicants = new ObservableCollection<DBApplicant>();
        CancellationTokenSource cancellationToken = new CancellationTokenSource();
        public ApplicantList()
		{
			InitializeComponent();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            FormView.ItemsSource = Applicants;
            GetApplicants();
        }

        private void GetApplicants()
        {
            Applicants.Clear();
            List<DBApplicant> dbApplicants;
            if (string.IsNullOrWhiteSpace(edSearchBarName.Text))
                dbApplicants = Task.Run(() => App.DB.GetApplicants()).Result;
            else
                dbApplicants = Task.Run(() => App.DB.SearchApplicants(edSearchBarName.Text)).Result;
            foreach (DBApplicant applicant in dbApplicants)
                Applicants.Add(applicant);
        }

        private async void FormView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                if (e.Item != null && CanStart("ShowApplicant"))
                {
                    DBApplicant dbApplicant = e.Item as DBApplicant;
                    await Navigation.PushAsync(new ApplicantDetails(dbApplicant));
                }
            }
            finally
            {
                EndTask("ShowApplicant");
            }
        }

        private void EdSearchBarName_SearchButtonPressed(object sender, EventArgs e)
        {
            GetApplicants();
        }

        private void EdSearchBarName_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Delay search by 500 milliseconds after typing. 
            //Doing it this way ensures that only one call to GetApplicants is made.
            Interlocked.Exchange(ref cancellationToken, new CancellationTokenSource()).Cancel();
            Task.Delay(TimeSpan.FromMilliseconds(500), cancellationToken.Token)
                .ContinueWith(
                    delegate { GetApplicants(); },
                    CancellationToken.None,
                    TaskContinuationOptions.OnlyOnRanToCompletion,
                    TaskScheduler.FromCurrentSynchronizationContext());
        }

        private async void Import_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ApplicantImport());
            GetApplicants();
        }
    }
}