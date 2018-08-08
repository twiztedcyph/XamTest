using FCA.Helpers;
using Pellcomp.Vs.Mobile.FormCaptureApp.lib;
using System;
using Xamarin.Forms;
using XamTest.Helpers;

namespace FCA.Forms
{
	public partial class MainPage : FCAContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            SetupIndicator(pnMain);
            btnForms.BackgroundColor = PelColours.StaticList.Success;
            btnApplicants.BackgroundColor = PelColours.StaticList.Info;
            btnLearners.BackgroundColor = PelColours.StaticList.Info;
            btnCompanies.BackgroundColor = PelColours.StaticList.Info;
            btnTools.BackgroundColor = PelColours.StaticList.Warning;
            btnDebugOptions.BackgroundColor = PelColours.StaticList.Error;
            lblVersion.TextColor = PelColours.StaticList.Border;
            lblVersion.HorizontalTextAlignment = TextAlignment.Center;
            lblVersion.Margin = new Thickness(10);
            lblVersion.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
            lblVersion.Text = "App Version " + App.Version;

            lblPICSVersion.TextColor = PelColours.StaticList.Border;
            lblPICSVersion.HorizontalTextAlignment = TextAlignment.Center;
            lblPICSVersion.Margin = new Thickness(10);
            lblPICSVersion.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
            //lblPICSVersion.Text = "PICS Version " + PICSDesktopVer.BuildNumber + " " + PICSDesktopVer.BuildDateString;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            btnApplicants.IsVisible = Settings.GetBool(oPICSConfig.cfgKey_FCA_Apps_Enabled, false);
            btnLearners.IsVisible = Settings.GetBool(oPICSConfig.cfgKey_FCA_Learners_Enabled, false);

            btnDebugOptions.IsVisible = Settings.DebugOptions.Debug;

            if (Settings.IsNewLogin)
            {
                Settings.IsNewLogin = false;
                await App.Current.MainPage.DisplayInfo("As this is a new login, you will now be taken to the Tools page" +
                    " where you are able to select the type of connection this app should use in the future.");
                await Navigation.PushAsync(new ToolsPage());
            }
        }

        public async void btnForms_Clicked(object sender, EventArgs args)
        {
            if (CanStart("btnFormsClicked"))
            {
                //await Navigation.PushAsync(new FormList());
                EndTask("btnFormsClicked");
            }
        }

        public async void btnApplicants_Clicked(object sender, EventArgs args)
        {
            if (CanStart("btnApplicantsClicked"))
            {
                //await Navigation.PushAsync(new ApplicantList());
                EndTask("btnApplicantsClicked");
            }
        }

        public async void btnTools_Clicked(object sender, EventArgs args)
        {
            if (CanStart("btnToolsClicked"))
            {
                await Navigation.PushAsync(new ToolsPage());
                EndTask("btnToolsClicked");
            }
        }

        public async void btnDebugOptions_Clicked(object sender, EventArgs args)
        {
            if (CanStart("btnDebugClicked"))
            {
                //await Navigation.PushAsync(new DebugOptionsPage());
                EndTask("btnDebugClicked");
            }
        }

        public async void btnCompanies_Clicked(object sender, EventArgs args)
        {
            if (CanStart("btnOrgsClicked"))
            {
                //await Navigation.PushAsync(new OrganisationsList());
                EndTask("btnOrgsClicked");
            }
        }

        private async void btnSync_Clicked(object sender, EventArgs e)
        {
            if (CanStart("btnSync_Clicked"))
            {
                Progress(true);
                //Settings.LastBaseDataSync = DateTime.MinValue;
                //SyncData syncPage = new SyncData();
                //await Navigation.PushModalAsync(syncPage);
                //await syncPage.SyncAllData();
                //if (Navigation.ModalStack.Contains(syncPage))
                //    await Navigation.PopModalAsync();
                //Progress(false);
                //await App.Current.ShowUpdatePassword();
                EndTask("btnSync_Clicked");
            }
        }

        private void btnHelp_Clicked(object sender, EventArgs e)
        {
            //Device.OpenUri(new Uri(HELP_URL));
        }

        public async void btnLearners_Clicked(object sender, EventArgs args)
        {
            if (CanStart("btnLearnersClicked"))
            {
                //await Navigation.PushAsync(new LearnersList());
                EndTask("btnLearnersClicked");
            }
        }
    }
}
