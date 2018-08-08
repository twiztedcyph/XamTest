using Xamarin.Forms;

namespace FCA.Controls
{
    public class PellButton : Button
    {
        public PellButton()
            : base()
        {
            const int _animationTime = 100;
            Clicked += async (sender, e) =>
            {
                var btn = (PellButton)sender;
                await btn.ScaleTo(1.2, _animationTime);
                await btn.ScaleTo(1, _animationTime);
            };
        }
    }
}
