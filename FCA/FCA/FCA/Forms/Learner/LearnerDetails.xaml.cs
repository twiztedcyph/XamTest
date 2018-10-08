using FCA.Models;
using System;
using Xamarin.Forms.Xaml;

namespace FCA.Forms.Learner
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LearnerDetails : FCAContentPage
	{
        DBLearner _learner;

		public LearnerDetails (DBLearner learner)
		{
			InitializeComponent ();
            _learner = learner;
            slLearner.BindingContext = _learner;
		}

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            if (CanStart("btnAddFormClicked"))
            {
                //Add learner form
                EndTask("btnAddFormClicked");
            }
        }

        private async void BtnDelet_Clicked(object sender, EventArgs e)
        {
            await App.DB.DeleteSingleLearner(_learner);
            await Navigation.PopAsync();
        }
    }
}