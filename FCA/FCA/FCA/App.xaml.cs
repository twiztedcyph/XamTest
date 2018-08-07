using FCA.Helpers;
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

        //TODO:This will need removing.
        public void SetupSoap()
        {
            Settings.WebServiceURL = "http://ian.pellcomp.net/PICSWebService/PICSWebService.svc";
            soapService = DependencyService.Get<ISoapService>();
        }
	}
}
