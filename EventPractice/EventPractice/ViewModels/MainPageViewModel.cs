using Microsoft.Practices.Unity;
using Prism.Unity;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Events;

namespace EventPractice.ViewModels
{
	public class MainPageViewModel : BindableBase, INavigationAware
	{
		private string _title;
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}


        #region Input Text
        private string _inputText;
        /// <summary>
        /// Input Text
        /// </summary>
        public string InputText
        {
            get { return this._inputText; }
            set { this.SetProperty(ref this._inputText, value); }
        }
        #endregion


        #region Sub Text
        private string _subText;
        /// <summary>
        /// Sub Text
        /// </summary>
        public string SubText
        {
            get { return this._subText; }
            set { this.SetProperty(ref this._subText, value); }
        }
        #endregion


        public DelegateCommand PubCommand { get; set; }


        public MainPageViewModel(IEventAggregator eventAggregator)
		{
            PubCommand = new DelegateCommand(() =>
            {
                eventAggregator.GetEvent<SayHelloEvent>().Publish(InputText);
            });

            eventAggregator.GetEvent<SayHelloEvent>().Subscribe((message) =>
            {
                SubText = message;
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

