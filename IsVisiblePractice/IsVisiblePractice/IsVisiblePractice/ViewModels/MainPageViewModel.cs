using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IsVisiblePractice.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {

        #region IsText1Visible
        private bool _isText1Visible;
        /// <summary>
        /// PropertyDescription
        /// </summary>
        public bool IsText1Visible
        {
            get { return this._isText1Visible; }
            set { this.SetProperty(ref this._isText1Visible, value); }
        }
        #endregion

        #region IsText2Visible
        private bool _isText2Visible;
        /// <summary>
        /// PropertyDescription
        /// </summary>
        public bool IsText2Visible
        {
            get { return this._isText2Visible; }
            set { this.SetProperty(ref this._isText2Visible, value); }
        }
        #endregion

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }


        public DelegateCommand Toggle1Command { get; set; }

        public DelegateCommand Toggle2Command { get; set; }

        public MainPageViewModel()
        {
            IsText1Visible = true;
            IsText2Visible = true;

            Toggle1Command = new DelegateCommand(() =>
            {
                IsText1Visible = !IsText1Visible;
            });

            Toggle2Command = new DelegateCommand(() =>
            {
                IsText2Visible = !IsText2Visible;
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
