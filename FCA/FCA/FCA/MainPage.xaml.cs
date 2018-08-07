using FCA.Interfaces;
using Xamarin.Forms;

namespace FCA
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            App.Current.SetupSoap();
            var v = App.soapService.FindApplicants(new FindApplicantsSoapRequest() { Surname = "A", Forenames = "A", RecruitmentOfficer = string.Empty, Sites = string.Empty});
		}
	}
}
