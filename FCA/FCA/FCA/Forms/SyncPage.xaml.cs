using FCA.Helpers;
using Plugin.Connectivity;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamTest.Helpers;

namespace FCA.Forms
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SyncPage : ContentPage
	{
		public SyncPage ()
		{
			InitializeComponent ();
		}

        public async Task SyncAllData()
        {
            try
            {
                await SyncHelper.SyncAll(lblProgress, aiLoading);
            }
            catch (Exception ex)
            {
                //Xamarin.Insights.Report(ex, "Process", "SyncAllData", Xamarin.Insights.Severity.Error);
                await this.DisplayException("SyncAllData", ex);
            }
        }

        public static async Task<bool> CheckForWifiOnly()
        {
            if (Settings.WifiOnly && !CrossConnectivity.Current.ConnectionTypes.Contains(Plugin.Connectivity.Abstractions.ConnectionType.WiFi))
            {
                await App.Current.MainPage.DisplayError("You are not connected to a WiFi network. Process aborted.");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}