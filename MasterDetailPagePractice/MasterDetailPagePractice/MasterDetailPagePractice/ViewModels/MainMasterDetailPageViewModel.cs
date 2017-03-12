using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MasterDetailPagePractice.ViewModels
{
    public class MainMasterDetailPageViewModel : BindableBase
    {


        public DelegateCommand GoPage1Command { get; set; }

        public DelegateCommand GoPage2Command { get; set; }

        public MainMasterDetailPageViewModel(INavigationService navigationService)
        {
            GoPage1Command = new DelegateCommand(async() =>
            {
                await navigationService.NavigateAsync("any:///MainMasterDetailPage/MainNavigationPage/Page1Page");
            });

            GoPage2Command = new DelegateCommand(async () =>
            {
                await navigationService.NavigateAsync("MainNavigationPage/Page2Page");
            });
        }
    }
}
