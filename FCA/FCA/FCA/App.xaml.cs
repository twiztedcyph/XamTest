using FCA.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamTest.Helpers;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace FCA
{
	public partial class App : Application
	{
        public static new App Current;
        public static int AnimationSpeed = 250;
        public static ISoapService soapService;
        public static string Version = "Unknown Version";
        public bool HadAuthenticationError { get; set; } = false;

        public App ()
		{
			InitializeComponent();
            Current = this;
            MainPage = new MainPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

        public void SetupSoap()
        {
            Settings.WebServiceURL = "http://ian.pellcomp.net/PICSWebService/PICSWebService.svc";
            soapService = DependencyService.Get<ISoapService>();
        }
	}
}
