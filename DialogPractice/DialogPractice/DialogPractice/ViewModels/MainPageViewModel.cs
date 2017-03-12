using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DialogPractice.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand SelectCommand { get; set; }

        public DelegateCommand WarningCommand { get; set; }


        public MainPageViewModel(IPageDialogService dialogService)
        {
            SelectCommand = new DelegateCommand(async () =>
            {
                var result = await dialogService.DisplayActionSheetAsync(
                    "Please Select",
                    "Cancel",
                    "Destroy",
                    new string[] { "Opt1", "Opt2", "Opt3" });

                await dialogService.DisplayAlertAsync("Select", result, "Cancel");
            });

            WarningCommand = new DelegateCommand(async () =>
            {
                await dialogService.DisplayAlertAsync("Warning", "Your account hase been suspended", "OK", "Cancel");
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
