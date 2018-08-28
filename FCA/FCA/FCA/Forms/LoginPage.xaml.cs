using FCA.Helpers;
using FCA.Models;
using FCA.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamTest.Helpers;

namespace FCA.Forms
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        public LoginPage()
        {
            InitializeComponent();
            edWebService.Text = Settings.WebServiceURL;
            edUsername.Text = Settings.UserName;
            edPassword.Text = Settings.Password;

            if (string.IsNullOrEmpty(edWebService.Text))
            {
                edWebService.Text = "http://ian.pellcomp.net/PICSWebService/PICSWebService.svc";
                edUsername.Text = "ian@valhalla.local";
                edPassword.Text = "1q2w3e4R";
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Task.Delay(300);
            await pnEntry.ScaleTo(1, (uint)App.AnimationSpeed, Easing.SinIn);
            await buttonStack.ScaleTo(1, (uint)App.AnimationSpeed, Easing.SinIn);
        }

        public void RefreshURL()
        {
            edWebService.Text = Settings.WebServiceURL;
        }

        async void btnLoginClicked(object sender, EventArgs args)
        {
            await DoLogin();
        }

        private async Task DoLogin()
        {
            if (!string.IsNullOrWhiteSpace(edWebService.Text) && !string.IsNullOrWhiteSpace(edUsername.Text) && !string.IsNullOrWhiteSpace(edPassword.Text))
            {
                lblProgress.Text = "Logging in...";
                pnEntryWrapper.IsVisible = false;
                pnProgress.IsVisible = true;
                try
                {
                    App.Current.SetupSoap(edWebService.Text);
                    var responseMessage = string.Empty;
                    GenericResponse<bool> loggedIn = await App.soapService.AuthenticateUser(edUsername.Text, edPassword.Text);

                    if (loggedIn.Data)
                    {
                        await this.DisplaySuccess("All logged in");
                        await TrySyncData();
                    }
                    else
                    {
                        ShowEntry();
                        await this.DisplayError(loggedIn.ResponseText, PelDialogButton.Retry);
                    }
                }
                catch (Exception ex)
                {
                    ShowEntry();
                    await this.DisplayException("process login", ex);
                }
            }
        }

        private async Task TrySyncData()
        {
            try
            {
                SyncPage syncPage = new SyncPage();
                await Navigation.PushModalAsync(syncPage);
                await syncPage.SyncAllData();
                var list = await App.DB.GetForms(false);
                var msg = "Forms: " + list.Count;
                var listFields = await App.DB.AsyncDb.Table<DBFormField>().ToListAsync();
                msg += " - Fields: " + listFields.Count;
                await this.DisplaySuccess("Sync Done: " + msg);
                if (Navigation.ModalStack.Contains(syncPage))
                    await Navigation.PopModalAsync();
                App.Current.ShowMainPage();
            }
            catch (Exception ex)
            {
                //Insights.Report(ex, Insights.Severity.Error);
                throw;
            }
        }

        private void ShowEntry()
        {
            pnProgress.IsVisible = false;
            pnEntryWrapper.IsVisible = true;
        }

        private void edWebService_Completed(object sender, EventArgs e)
        {

        }

        async void edPassword_Completed(object sender, EventArgs e)
        {
            await DoLogin();
        }
    }
}