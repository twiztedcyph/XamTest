using Xamarin.Forms;

namespace FCA.Helpers
{
    public class PelColours
    {
        private static PelColours _staticList;
        public static PelColours StaticList
        {
            get
            {
                if (_staticList == null)
                    _staticList = new PelColours();
                return _staticList;
            }
        }

        public Color Text { get { return Color.FromHex("#666666"); } }
        public Color Toolbar { get { return Color.FromHex("#efefef"); } }
        public Color Border { get { return Color.FromHex("#dddddd"); } }
        public Color MainBar { get { return Color.FromHex("#49586f"); } }
        public Color Link { get { return Color.FromHex("#165783"); } }
        public Color Info { get { return Color.FromHex("#3a7fc4"); } }
        public Color InfoDark { get { return Color.FromHex("#142C44"); } }
        public Color InfoText { get { return Color.FromHex("#ffffff"); } }
        public Color Success { get { return Color.FromHex("#8eb021"); } }
        public Color Warning { get { return Color.FromHex("#f6c341"); } }
        public Color Error { get { return Color.FromHex("#d04437"); } }
        public Color Lightbulb { get { return Color.FromHex("#8a39c4"); } }
    }
}
