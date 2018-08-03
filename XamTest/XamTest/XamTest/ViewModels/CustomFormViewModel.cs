using System.Collections.ObjectModel;
using XamTest.Models;

namespace XamTest.ViewModels
{
    public class CustomFormViewModel
    {
        public static ObservableCollection<DBCustomForm> GetForms { get; set; } = new ObservableCollection<DBCustomForm>(App.DB.GetAllForms());
    }
}
