using FCA.Helpers;
using FCA.Interfaces;
using FCA.Models;
using FCA.Shared;
using Pellcomp.Vs.Mobile.FormCaptureApp.lib;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;
using XamTest.Helpers;

namespace FCA.Forms.Learner
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LearnerImport : FCAContentPage
	{
		public LearnerImport ()
		{
			InitializeComponent ();
		}

        private async void BtnImort_Clicked(object sender, EventArgs e)
        {
            if (CanStart("OnImportLearnersClicked"))
            {
                if (await SyncHelper.CheckForWifiOnly())
                {
                    aiLoading.IsVisible = true;
                    aiLoading.IsRunning = true;
                    BtnImport.IsVisible = false;
                    string searchTextSurname = edSurname.Text;
                    string searchTextForenames = edFornames.Text;
                    string searchTextPostcode = edPostcode.Text;
                    string searchTextMainOff = "";
                    if (Settings.GetBool(oPICSConfig.cfgKey_FCA_Learners_Filter_MainOff, true))
                        searchTextMainOff = Settings.OfficerCode;
                    string searchTextSites = Settings.UserSites;

                    if (string.IsNullOrWhiteSpace(searchTextSurname) || string.IsNullOrWhiteSpace(searchTextForenames))
                    {
                        await this.DisplayError("Surname and Forename are both required to search for Learners", PelDialogButton.Retry);
                    }
                    else
                    {
                        FindLearnersSoapRequest req = new FindLearnersSoapRequest()
                        {
                            Surname = searchTextSurname,
                            Forename = searchTextForenames,
                            Postcode = searchTextPostcode,
                            MainOfficer = searchTextMainOff,
                            Sites = searchTextSites
                        };
                        GenericResponse<List<DBLearner>> learners = await App.soapService.FindLearners(req);
                        if ((learners == null) || (learners.Data == null) || (learners.Data.Count == 0))
                        {
                            await this.DisplayError("No learners found matching your search options", PelDialogButton.Retry);
                        }
                        else
                        {
                            int allowedMonthsOld = 12; //Settings.GetInt(oPICSConfig.cfgKey_FCA_Learners_Filter_OldLearners_Months, 12); //Fix later
                            int leftTooLongAgo = 0;
                            foreach (DBLearner learner in learners.Data)
                            {
                                if (learner.TrainingEnd.HasValue &&
                                    learner.TrainingEnd.Value > DateTime.MinValue &&
                                    learner.TrainingEnd.Value.AddMonths(allowedMonthsOld) <= DateTime.Now)
                                {
                                    leftTooLongAgo++;
                                }
                                else
                                {
                                    await App.DB.SaveLearner(learner);
                                }
                            }
                            await PruneOldLearners();
                            string message = $"{learners.Data.Count} learner(s) found.{Environment.NewLine}";
                            if (leftTooLongAgo > 0)
                            {
                                if (allowedMonthsOld > 0)
                                    message += $"{leftTooLongAgo} episodes that ended more than {allowedMonthsOld} month(s) ago were not added.";
                                else
                                    message += $"{leftTooLongAgo} episodes that have ended were not added.";
                            }
                            await this.DisplaySuccess(message);
                            await Navigation.PopAsync();
                        }
                        await App.Current.ShowUpdatePassword();
                    }
                    aiLoading.IsVisible = false;
                    aiLoading.IsRunning = false;
                    BtnImport.IsVisible = true;
                }
                EndTask("OnImportLearnersClicked");
            }
        }

        private async Task PruneOldLearners()
        {
            // Delete any learners downloaded more than 21 days ago
            await App.DB.DeleteLearnersByDownloadDate(DateTime.Now.AddDays(-21));
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}