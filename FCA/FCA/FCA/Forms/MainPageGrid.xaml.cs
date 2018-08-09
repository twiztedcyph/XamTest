using FCA.Controls;
using FCA.Helpers;
using Pellcomp.Vs.Mobile.FormCaptureApp.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamTest.Helpers;

namespace FCA.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageGrid : FCAContentPage
    {
        private Layout<View> _mainPageLayoutView;
        private List<Button> _buttons;
        private double _width, _height;

        public MainPageGrid()
        {
            InitializeComponent();
            SetButtons();
            SetToolBarItems();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SizeChanged += MainPageGrid_SizeChanged;
            AdaptLayout(true);
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (_width != width || _height != height)
            {
                _width = width;
                _height = height;
            }
        }

        private void MainPageGrid_SizeChanged(object sender, EventArgs e)
        {
            AdaptLayout(false);
        }

        private void AdaptLayout(bool setContent)
        {
            bool layoutChanged = false;


            if (Device.Idiom == TargetIdiom.Desktop)
            {
                if (_width >= 1000 && (setContent || Content is StackLayout))
                {
                    SetDesktopLayout();
                    layoutChanged = true;
                }
                else if (_width < 1000 && (setContent || Content is Grid))
                {
                    SetMobilePortraitLayout();
                    layoutChanged = true;
                }
            }
            else
            {
                if (_height >= _width && (setContent || Content is Grid))
                {
                    SetMobilePortraitLayout();
                    layoutChanged = true;
                }
                else if (_width > _height && (setContent || Content is StackLayout))
                {
                    SetMobileLandscapeLayout();
                    layoutChanged = true;
                }
            }

            if (layoutChanged || setContent)
            {
                Content =_mainPageLayoutView;
            }
        }


        private void SetButtons()
        {
            Button btnLearners = new PellGridButton(3, 1, 1, 1) { Text = "Learners", BackgroundColor = PelColours.StaticList.Info };
            btnLearners.IsVisible = Settings.GetBool(oPICSConfig.cfgKey_FCA_Learners_Enabled, true); //TODO: Make default false;
            btnLearners.Clicked += BtnLearners_Clicked;

            Button btnApplicants = new PellGridButton(3, 2, 1, 1) { Text = "Applicants", BackgroundColor = PelColours.StaticList.Info };
            btnApplicants.IsVisible = Settings.GetBool(oPICSConfig.cfgKey_FCA_Apps_Enabled, true); //TODO: Make default false;
            btnApplicants.Clicked += BtnApplicants_Clicked;

            Button btnForms = new PellGridButton(1, 1, 2, 2) { Text = "Forms", BackgroundColor = PelColours.StaticList.Success};
            btnForms.Clicked += BtnForms_Clicked;

            Button btnCompanies = new PellGridButton(btnLearners.IsVisible ? 4 : 3, 1, 2, 1) { Text = "Companies", BackgroundColor = PelColours.StaticList.Info };
            btnCompanies.Clicked += BtnCompanies_Clicked;

            Button btnTools = new PellGridButton(btnApplicants.IsVisible ? 4 : 3, 2, 1, 1) { Text = "Tools", BackgroundColor = PelColours.StaticList.Warning };
            btnTools.Clicked += BtnTools_Clicked;

            Button btnExit = new PellGridButton(btnApplicants.IsVisible ? 5 : 4, 2, 1, 1) { Text = "Exit", BackgroundColor = PelColours.StaticList.Error };
            btnExit.Clicked += BtnExit_Clicked;

            _buttons = new List<Button>() { btnForms, btnLearners, btnApplicants, btnCompanies, btnTools, btnExit };
        }

        private void SetToolBarItems()
        {
            ToolbarItem btnSync = new ToolbarItem() { Text = "Sync", Order = ToolbarItemOrder.Primary, Icon = "sync.png" };
            btnSync.Clicked += BtnSync_Clicked;
            ToolbarItems.Add(btnSync);

            ToolbarItem btnExit = new ToolbarItem() { Text = "Exit", Order = ToolbarItemOrder.Primary, Icon = "exit.png" };
            btnExit.Clicked += BtnExit_Clicked;
            ToolbarItems.Add(btnExit);
        }

        private void SetLayoutView()
        {
            switch (Device.Idiom)
            {
                case TargetIdiom.Desktop:
                case TargetIdiom.Tablet:
                    SetDesktopLayout();
                    break;
                case TargetIdiom.Phone:
                    SetMobilePortraitLayout();
                    break;
                default:
                    throw new NotSupportedException("The device you are using is not supported.");
            }
        }

        private void SetDesktopLayout()
        {
            //7x4 for desktop and tablet. This allows for the FCA look
            _mainPageLayoutView = new Grid()
            {
                RowSpacing = 1,
                ColumnSpacing = 1
            };
            //Columns
            (_mainPageLayoutView as Grid).ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            (_mainPageLayoutView as Grid).ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(200) });
            (_mainPageLayoutView as Grid).ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(200) });
            (_mainPageLayoutView as Grid).ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(200) });
            (_mainPageLayoutView as Grid).ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(200) });
            if (_buttons.Where(x => x.IsVisible).Count() >= 5)
            {
                (_mainPageLayoutView as Grid).ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(200) });
                (_mainPageLayoutView as Grid).ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }
            else
                (_mainPageLayoutView as Grid).ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            //Rows
            (_mainPageLayoutView as Grid).RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            (_mainPageLayoutView as Grid).RowDefinitions.Add(new RowDefinition { Height = new GridLength(200) });
            (_mainPageLayoutView as Grid).RowDefinitions.Add(new RowDefinition { Height = new GridLength(200) });
            (_mainPageLayoutView as Grid).RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            foreach (PellGridButton button in _buttons)
            {
                (_mainPageLayoutView as Grid).Children.Add(button, button.LayoutParams[0], button.LayoutParams[1]);
                Grid.SetColumnSpan(button, button.LayoutParams[2]);
                Grid.SetRowSpan(button, button.LayoutParams[3]);
            }
        }

        private void SetMobileLandscapeLayout()
        {
            //7x4 for desktop and tablet. This allows for the FCA look
            _mainPageLayoutView = new Grid()
            {
                RowSpacing = 1,
                ColumnSpacing = 1
            };
            //Columns
            (_mainPageLayoutView as Grid).ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            (_mainPageLayoutView as Grid).ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            (_mainPageLayoutView as Grid).ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            (_mainPageLayoutView as Grid).ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            if (_buttons.Where(x => x.IsVisible).Count() >= 5)
            {
                (_mainPageLayoutView as Grid).ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }
            //Rows
            (_mainPageLayoutView as Grid).RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            (_mainPageLayoutView as Grid).RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            int colIndex = 1;
            foreach (PellGridButton button in _buttons)
            {
                (_mainPageLayoutView as Grid).Children.Add(button, button.LayoutParams[0]-1, button.LayoutParams[1]-1);
                Grid.SetColumnSpan(button, button.LayoutParams[2]);
                Grid.SetRowSpan(button, button.LayoutParams[3]);
            }
        }

        private void SetMobilePortraitLayout()
        {
            //StackLayout for mobile
            _mainPageLayoutView = new StackLayout()
            {
                Spacing = 10,
                Padding = 10
            };

            foreach (Button button in _buttons)
            {
                (_mainPageLayoutView as StackLayout).Children.Add(button);
            }
        }

        private void BtnExit_Clicked(object sender, EventArgs e)
        {
            //
        }

        public async void BtnForms_Clicked(object sender, EventArgs args)
        {
            if (CanStart("BtnFormsClicked"))
            {
                //await Navigation.PushAsync(new FormList());
                EndTask("BtnFormsClicked");
            }
        }

        public async void BtnApplicants_Clicked(object sender, EventArgs args)
        {
            if (CanStart("BtnApplicantsClicked"))
            {
                await Navigation.PushAsync(new ApplicantList());
                EndTask("BtnApplicantsClicked");
            }
        }

        public async void BtnTools_Clicked(object sender, EventArgs args)
        {
            if (CanStart("BtnToolsClicked"))
            {
                await Navigation.PushAsync(new ToolsPage());
                EndTask("BtnToolsClicked");
            }
        }

        public async void BtnDebugOptions_Clicked(object sender, EventArgs args)
        {
            if (CanStart("BtnDebugClicked"))
            {
                //await Navigation.PushAsync(new DebugOptionsPage());
                EndTask("BtnDebugClicked");
            }
        }

        public async void BtnCompanies_Clicked(object sender, EventArgs args)
        {
            if (CanStart("BtnOrgsClicked"))
            {
                //await Navigation.PushAsync(new OrganisationsList());
                EndTask("BtnOrgsClicked");
            }
        }

        private async void BtnSync_Clicked(object sender, EventArgs e)
        {
            if (CanStart("BtnSync_Clicked"))
            {
                Progress(true);
                Settings.LastBaseDataSync = DateTime.MinValue;
                SyncPage syncPage = new SyncPage();
                await Navigation.PushModalAsync(syncPage);
                await syncPage.SyncAllData();
                if (Navigation.ModalStack.Contains(syncPage))
                    await Navigation.PopModalAsync();
                Progress(false);
                //await App.Current.ShowUpdatePassword();
                EndTask("BtnSync_Clicked");
            }
        }

        private void BtnHelp_Clicked(object sender, EventArgs e)
        {
            //Device.OpenUri(new Uri(HELP_URL));
        }

        public async void BtnLearners_Clicked(object sender, EventArgs args)
        {
            if (CanStart("BtnLearnersClicked"))
            {
                //await Navigation.PushAsync(new LearnersList());
                EndTask("BtnLearnersClicked");
            }
        }
    }
}