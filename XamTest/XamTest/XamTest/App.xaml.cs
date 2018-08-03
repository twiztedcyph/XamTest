using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamTest.Helpers;
using XamTest.Shared;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace XamTest
{
	public partial class App : Application
	{
        public const int ANIMATION_SPEED = 250;
        public static ISoapService soapService;
        public static string Version { get; set; } = "Unknown Version";
        public bool HadAuthenticationError { get; set; }

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

            DB.CreateTables();

			MainPage = new NavigationPage(new MainPage());
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
	}
}
