using Windows.Foundation;
using Windows.UI.ViewManagement;

namespace FCA.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new FCA.App());

            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(400, 600));
        }
    }
}
