﻿using Prism.Unity;
using ListViewPractice_01_Basic.Views;

namespace ListViewPractice_01_Basic
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("NaviPage/MainPage?title=Hello%20from%20Xamarin.Forms");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<NaviPage>();
            Container.RegisterTypeForNavigation<StudentDataPage>();
        }
    }
}
