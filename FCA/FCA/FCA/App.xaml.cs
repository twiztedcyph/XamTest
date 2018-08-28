using FCA.Forms;
using FCA.Helpers;
using FCA.Interfaces;
using System.Threading.Tasks;
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

        private static Database _DB;
        public static Database DB
        {
            get
            {
                if (_DB == null)
                    _DB = new Database();
                return _DB;
            }
        }

        public App ()
		{
			InitializeComponent();
            Current = this;

            DB.CreateTables();

            if (Settings.LoggedIn)
                ShowMainPage();
            else
                ShowLoginPage();
        }

        public void ShowLoginPage()
        {
            MainPage = new NavigationPage(new LoginPage());
        }

        public void ShowMainPage()
        {
            MainPage = new NavigationPage(new MainPageGrid());
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

        //TODO:This will need removing.
        public void SetupSoap(string webServiceURL)
        {
            Settings.WebServiceURL = webServiceURL;
            soapService = DependencyService.Get<ISoapService>();
        }

        public async Task ShowUpdatePassword()
        {
            if (this.HadAuthenticationError)
            {
                if (await MainPage.DisplayYesNoAlert("We failed to connect to PICS. This often means that your password has been updated in PICS. Would you like to enter your current password now?"))
                {
                    //await MainPage.Navigation.PushModalAsync(new UpdatePassword());
                }
                else
                    this.HadAuthenticationError = false;
            }
        }
    }
}
