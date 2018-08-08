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

    public class PellGridButton : PellButton
    {
        //
        public int[] LayoutParams { get; set; } = new int[4];
        public PellGridButton(int left, int top, int colSpan, int rowSpan) : base()
        {
            LayoutParams[0] = left;
            LayoutParams[1] = top;
            LayoutParams[2] = colSpan;
            LayoutParams[3] = rowSpan;
        }
    }
}
