using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeepNavigationPractice.ViewModels
{
    public class Page4ViewModel : BindableBase
    {
        public DelegateCommand GoHomePageCommand { get; set; }

        public Page4ViewModel(INavigationService navigationService, Prism.Events.EventAggregator ea)
        {
            ea.GetEvent<ColorChangeEvent>().Publish("Black");
            GoHomePageCommand = new DelegateCommand(async () =>
            {
                await navigationService.NavigateAsync("any:///MainNavigationPage/MainPage");
            });

            
        }
    }
}
