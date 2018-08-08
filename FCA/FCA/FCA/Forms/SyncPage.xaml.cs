using FCA.Helpers;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
    }
}