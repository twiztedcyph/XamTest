﻿using FCA.Forms.Learner;
using FCA.Models;
using Microsoft.Rest;
using Pellcomp;
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
	public partial class LearnerList : FCAContentPage
    {
        readonly ObservableCollection<DBLearner> Learners = new ObservableCollection<DBLearner>();
        CancellationTokenSource cancellationToken = new CancellationTokenSource();
        public LearnerList ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            FormView.ItemsSource = Learners;
            GetLearners();
        }

        private void GetLearners()
        {
            var credentials = new BasicAuthenticationCredentials();
            credentials.UserName = "ian@pellcomp.local";
            credentials.Password = "1q2w3e4R";
            var l = new Learners(new PICSWeb());
            var v = l.SearchAsync("Sha", "Aan", "");

            List<DBLearner> dbLearners = null;

            string surnameSearchText = EdSearchBarName.Text;
            if (string.IsNullOrWhiteSpace(surnameSearchText))
                dbLearners = Task.Run(() => App.DB.GetLearners()).Result;
            else
                dbLearners = Task.Run(() => App.DB.SearchLearnersByName(surnameSearchText)).Result;

            Learners.Clear();
            foreach (DBLearner learner in dbLearners)
                Learners.Add(learner);
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LearnerImport());
        }

        private void EdSearchBarName_SearchButtonPressed(object sender, EventArgs e)
        {
            GetLearners();
        }

        private void EdSearchBarName_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Delay search by 500 milliseconds after typing. 
            //Doing it this way ensures that only one call to GetApplicants is made.
            Interlocked.Exchange(ref cancellationToken, new CancellationTokenSource()).Cancel();
            Task.Delay(TimeSpan.FromMilliseconds(500), cancellationToken.Token)
                .ContinueWith(
                    delegate { GetLearners(); },
                    CancellationToken.None,
                    TaskContinuationOptions.OnlyOnRanToCompletion,
                    TaskScheduler.FromCurrentSynchronizationContext());
        }

        private async void FormView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                if (e.Item != null && CanStart("ShowLearner"))
                {
                    DBLearner dbLearner = e.Item as DBLearner;
                    await Navigation.PushAsync(new LearnerDetails(dbLearner));
                }
            }
            finally
            {
                EndTask("ShowLearner");
            }
        }
    }
}