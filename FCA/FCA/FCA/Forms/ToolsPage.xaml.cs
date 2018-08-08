using FCA.Helpers;
using PCLStorage;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamTest.Helpers;

namespace FCA.Forms
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ToolsPage : ContentPage
	{
        public ToolsPage()
        {
            InitializeComponent();
            btnLogout.BackgroundColor = PelColours.StaticList.Error;
            swWifiOnly.IsToggled = Settings.WifiOnly;
            swWifiOnly.Toggled += SwWifiOnly_Toggled;
            lblUsername.Text = Settings.UserName;
            FormattedString wifiOnlyText = new FormattedString();
            wifiOnlyText.Spans.Add(new Span { Text = "WiFi only sync", FontSize = 15, FontAttributes = FontAttributes.Bold });
            wifiOnlyText.Spans.Add(new Span { Text = Environment.NewLine + "Select this option to only synchronise if the device is connected to a WiFi network.", FontSize = 15 });
            lblWifiOnly.FormattedText = wifiOnlyText;
        }

        private void SwWifiOnly_Toggled(object sender, ToggledEventArgs e)
        {
            Settings.WifiOnly = swWifiOnly.IsToggled;
        }

        private async void btnLogout_Clicked(object sender, EventArgs e)
        {
            if (await this.DisplayYesNoAlert("Are you sure you want to logout? Any work not syched will be lost?"))
            {
                App.DB.DropAndCreateDatabase();
                Settings.LoggedIn = false;
                Settings.OfficerCode = string.Empty;
                Settings.Password = string.Empty;
                Settings.AuthToken = string.Empty;
                Settings.FullName = string.Empty;
                Settings.ClearUsername = string.Empty;
                Settings.EmailAddress = string.Empty;
                Settings.UserSites = string.Empty;
                Settings.LastBaseDataSync = DateTime.MinValue;
                Settings.WifiOnly = false;
                Settings.IsNewLogin = true;
                IFolder localStorage = FileSystem.Current.LocalStorage;
                ExistenceCheckResult exists = await localStorage.CheckExistsAsync(SyncHelper.FormsFolder);
                if (exists == ExistenceCheckResult.FolderExists)
                {
                    IFolder formsFolder = await localStorage.GetFolderAsync(SyncHelper.FormsFolder);
                    if (formsFolder != null)
                        await formsFolder.DeleteAsync();
                }
                App.Current.ShowLoginPage();
            }
        }
    }
}