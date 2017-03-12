using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CanExecuteCommandPractice.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        #region Account
        private string _account;
        /// <summary>
        /// Account
        /// </summary>
        public string Account
        {
            get { return this._account; }
            set
            {
                this.SetProperty(ref this._account, value);
                LoginCommand.RaiseCanExecuteChanged();
            }
        }
        #endregion


        #region Input Information
        private string _inputInfo;
        /// <summary>
        /// Input information
        /// </summary>
        public string InputInfo
        {
            get { return this._inputInfo; }
            set { this.SetProperty(ref this._inputInfo, value); }
        }
        #endregion

        public DelegateCommand LoginCommand { get; set; }

        public MainPageViewModel()
        {
            LoginCommand = new DelegateCommand(() =>
            {
                InputInfo = "登入成功";
            }, () =>
            {
                return !String.IsNullOrEmpty(Account) && Account.Length > 4;
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
