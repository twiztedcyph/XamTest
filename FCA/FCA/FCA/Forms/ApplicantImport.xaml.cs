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

namespace FCA.Forms
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ApplicantImport : FCAContentPage
    {
		public ApplicantImport ()
		{
			InitializeComponent ();
		}

        private async void btnImport_Clicked(object sender, EventArgs e)
        {
            const string CTaskName = "OnImportApplicantsClicked";
            if (CanStart(CTaskName))
            {
                if (await SyncPage.CheckForWifiOnly())
                {
                    aiLoading.IsVisible = true;
                    aiLoading.IsRunning = true;
                    btnImport.IsVisible = false;
                    string searchTextSurname = edSurname.Text;
                    string searchTextForenames = edFornames.Text;
                    string searchTextPostcode = edPostcode.Text;
                    string searchTextRecrOff = "";
                    if (Settings.GetBool(oPICSConfig.cfgKey_FCA_Apps_Filter_RecrOff, false))
                        searchTextRecrOff = Settings.OfficerCode;
                    string searchTextSites = Settings.UserSites;

                    if (string.IsNullOrWhiteSpace(searchTextSurname) || string.IsNullOrWhiteSpace(searchTextForenames))
                    {
                        await this.DisplayError("Surname and Forename are both required to search for Applicants", PelDialogButton.Retry);
                    }
                    else
                    {
                        FindApplicantsSoapRequest req = new FindApplicantsSoapRequest
                        {
                            Surname = searchTextSurname,
                            Forenames = searchTextForenames,
                            Postcode = searchTextPostcode,
                            RecruitmentOfficer = searchTextRecrOff,
                            Sites = searchTextSites
                        };
                        GenericResponse<List<DBApplicant>> applicants = Task.Run(() => App.soapService.FindApplicants(req)).Result;
                        if ((applicants == null) || (applicants.Data == null) || (applicants.Data.Count == 0))
                        {
                            await this.DisplayError("No applicants found matching your search options", PelDialogButton.Retry);
                        }
                        else
                        {
                            foreach (DBApplicant item in applicants.Data)
                            {
                                await App.DB.SaveApplicant(item);
                            }
                            await PruneOldApplicants();
                            await this.DisplaySuccess(applicants.Data.Count + " applicant(s) found");
                            await Navigation.PopAsync();
                        }
                        await App.Current.ShowUpdatePassword();
                    }
                    aiLoading.IsVisible = false;
                    aiLoading.IsRunning = false;
                    btnImport.IsVisible = true;
                }
                EndTask(CTaskName);
            }
        }

        private async void btnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async Task PruneOldApplicants()
        {
            // Delete any applicants downloaded more than 21 days ago
            await App.DB.DeleteApplicantsByDownloadDate(DateTime.Now.AddDays(-21));
        }

        private void btnImport_Clicked_1(object sender, EventArgs e)
        {

        }
    }
}