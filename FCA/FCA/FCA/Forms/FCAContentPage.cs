using FCA.Helpers;
using Plugin.DeviceInfo;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FCA.Forms
{
    public class FCAContentPage : ContentPage
    {
        private List<string> ActiveTasks = new List<string>();

        public bool CanStart(string TaskName)
        {
            if (ActiveTasks.Contains(TaskName))
            {
                return false;
            }
            else
            {
                ActiveTasks.Add(TaskName);
                return true;
            }
        }
        bool FirstShow = true;
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (FirstShow)
            {
                if (CrossDeviceInfo.Current.Platform == Plugin.DeviceInfo.Abstractions.Platform.Android)
                {
                    if (CrossDeviceInfo.Current.VersionNumber.Major < 6)
                    {
                        if (ToolbarItems != null)
                        {
                            foreach (var item in ToolbarItems)
                            {
                                if (item.Order == ToolbarItemOrder.Secondary)
                                {
                                    item.Order = ToolbarItemOrder.Primary;
                                }
                            }
                        }
                    }
                }

                FirstShow = false;

            }
        }

        public void EndTask(string TaskName)
        {
            if (ActiveTasks.Contains(TaskName))
                ActiveTasks.Remove(TaskName);
        }

        ActivityIndicator _indicator = null;
        protected void SetupIndicator(Layout<View> Wrapper)
        {
            if (_indicator == null)
            {
                _indicator = new ActivityIndicator();
                _indicator.IsRunning = false;
                Progress(false);
                Wrapper.Children.Insert(0, _indicator);
            }
        }

        protected void Progress(bool IsRunning)
        {
            if (_indicator != null)
            {
                _indicator.IsVisible = IsRunning;
                _indicator.IsRunning = IsRunning;
            }
        }

        private bool bPopped = false;
        protected async Task PopForm()
        {
            if (!bPopped)
            {
                bPopped = true;
                await Navigation.PopAsync();
            }
        }
        private bool PreventBackButton = false;
        private bool CanCancel = false;
        protected void DisableBackButton(bool CanCancel)
        {
            PreventBackButton = true;
            NavigationPage.SetHasBackButton(this, false);
            this.CanCancel = CanCancel;
        }
        protected override bool OnBackButtonPressed()
        {
            if (PreventBackButton)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    string sMessage = "Back button is disabled on this screen.";
                    if (CanCancel)
                        sMessage += " Use the cancel button to exit";
                    await this.DisplayInfo(sMessage);
                });

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
