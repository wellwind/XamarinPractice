using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeepNavigationPractice.ViewModels
{
    public class MainNavigationPageViewModel : BindableBase
    {

        #region PropertyName
        private string propertyName;
        /// <summary>
        /// PropertyDescription
        /// </summary>
        public string PropertyName
        {
            get { return this.propertyName; }
            set { this.SetProperty(ref this.propertyName, value); }
        }
        #endregion

        public MainNavigationPageViewModel(Prism.Events.EventAggregator ea)
        {
            PropertyName = "Blue";
            ea.GetEvent<ColorChangeEvent>().Subscribe((col) =>
            {
                PropertyName = col;
            });
        }
    }
}
