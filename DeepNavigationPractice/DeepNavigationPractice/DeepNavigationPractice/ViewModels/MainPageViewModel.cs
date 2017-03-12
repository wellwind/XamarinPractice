using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeepNavigationPractice.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private INavigationService _navigationService;

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand GoNextPageCommand { get; set; }

        public DelegateCommand AutoNavigationCommand { get; set; }


        public MainPageViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;

            GoNextPageCommand = new DelegateCommand(async () =>
            {
                await _navigationService.NavigateAsync("Page2");
            });

            AutoNavigationCommand = new DelegateCommand(async () =>
            {
                await _navigationService.NavigateAsync("Page2");
                await _navigationService.NavigateAsync("Page3");
                await _navigationService.NavigateAsync("Page4");

            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }
    }
}
