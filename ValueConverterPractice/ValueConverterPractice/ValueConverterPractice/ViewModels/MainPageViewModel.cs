using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ValueConverterPractice.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {

        #region InputColor
        private string _inputColor;
        /// <summary>
        /// PropertyDescription
        /// </summary>
        public string InputColor
        {
            get { return this._inputColor; }
            set { this.SetProperty(ref this._inputColor, value); }
        }
        #endregion

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainPageViewModel()
        {

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
