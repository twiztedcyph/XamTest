using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamTest.Helpers;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace XamTest
{
	public partial class App : Application
	{
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
