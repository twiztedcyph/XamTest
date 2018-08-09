using FCA.Models;
using System.Collections.ObjectModel;

namespace FCA.ViewModels
{
    public class ApplicantListViewModel
    {
        public static ObservableCollection<DBApplicant> ApplicantList { get; private set; }
        
        public ApplicantListViewModel()
        {
            ApplicantList = new ObservableCollection<DBApplicant>(App.DB.GetApplicants().Result);
        }
    }
}
