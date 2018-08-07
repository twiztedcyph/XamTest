using System.ComponentModel;

namespace FCA.Models
{
    public class BaseDbItem : INotifyPropertyChanged
    {
        //TODO: https://msdn.microsoft.com/en-us/magazine/mt736453.aspx

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
