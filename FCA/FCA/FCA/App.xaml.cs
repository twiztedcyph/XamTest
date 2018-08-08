using FCA.Forms;
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

            Resources["plainButton"] = new Style(typeof(Button)){
                    Setters = {
                    new Setter { Property = Button.BackgroundColorProperty, Value = Color.FromHex ("#eee") },
                    new Setter { Property = Button.TextColorProperty, Value = Color.Black },
                    new Setter { Property = Button.CornerRadiusProperty, Value = 2 },
                    new Setter { Property = Button.FontSizeProperty, Value = 40 }
                }
            };

            DB.CreateTables();

            //if (Settings.LoggedIn)
                ShowMainPage();
            //else
                //ShowLoginPage();
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
	}
}
