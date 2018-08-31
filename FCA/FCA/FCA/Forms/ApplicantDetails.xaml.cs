using FCA.Models;
using System;
using Xamarin.Forms.Xaml;

namespace FCA.Forms
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ApplicantDetails : FCAContentPage
	{
        DBApplicant _applicant;

		public ApplicantDetails (DBApplicant applicant)
		{
			InitializeComponent ();
            _applicant = applicant;
            slApplicant.BindingContext = _applicant;
        }

        private void ToolbarItem_Clicked(object sender, System.EventArgs e)
        {
            if (CanStart("btnAddFormClicked"))
            {
                //FormSelectPage selectPage = new FormSelectPage();
                //selectPage.DefaultApIdent = applicant.ApIdent;
                //selectPage.TypeFilter.Add(fldFormCapCommon.Form_Custom_AppEvent);
                //if (Settings.ServiceSupports(Settings.ServiceFeatures.ApprovedCRMActivityForms))
                //    selectPage.TypeFilter.Add(fldFormCapCommon.Form_Custom_AppEvent_Approve);
                //selectPage.TypeFilter.Add(fldFormCapCommon.Form_Custom_Learner);
                //await Navigation.PushAsync(selectPage);
                EndTask("btnAddFormClicked");
            }
        }
    }
}