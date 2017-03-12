using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeepNavigationPractice.ViewModels
{
    public class Page3ViewModel : BindableBase
    {
        public DelegateCommand GoNextPageCommand { get; set; }

        public Page3ViewModel(INavigationService navigationService)
        {
            GoNextPageCommand = new DelegateCommand(async () =>
            {
                await navigationService.NavigateAsync("Page4");
            });

        }
    }
}
