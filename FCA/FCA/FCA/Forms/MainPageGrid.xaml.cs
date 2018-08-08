using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FCA.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageGrid : ContentPage
    {
        public static Style plainButton = new Style(typeof(Button))
        {
            Setters = {
                new Setter { Property = BackgroundColorProperty, Value = Color.FromHex ("#eee") },
                new Setter { Property = Button.TextColorProperty, Value = Color.Black },
                new Setter { Property = Button.CornerRadiusProperty, Value = 2 },
                new Setter { Property = Button.FontSizeProperty, Value = 40 }
            }
        };

        public MainPageGrid()
        {
            InitializeComponent();
        }
    }
}