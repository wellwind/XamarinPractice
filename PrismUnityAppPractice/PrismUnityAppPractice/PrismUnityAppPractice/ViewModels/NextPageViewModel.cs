using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismUnityAppPractice.ViewModels
{
    public class NextPageViewModel : BindableBase, INavigationAware
    {
        private INavigationService _navigationService;
        #region Title
        private string _name;
        /// <summary>
        /// Title
        /// </summary>
        public string Name
        {
            get { return this._name; }
            set { this.SetProperty(ref this._name, value); }
        }
        #endregion

        public DelegateCommand GoBackCommand => new DelegateCommand(GoBack);

        private void GoBack()
        {
            this._navigationService.GoBackAsync();
        }

        public NextPageViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
  
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("name"))
            {
                var foo = parameters["name"] as string;
                Name = foo;
            }
            //if (parameters.ContainsKey("name"))
            //    Name = (string)parameters["name"] + " Inputed";
        }
    }
}
