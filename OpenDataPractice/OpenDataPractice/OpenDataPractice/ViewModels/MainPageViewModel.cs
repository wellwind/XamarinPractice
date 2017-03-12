using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDataPractice.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        #region 營建署所屬景點活動清單
        private ObservableCollection<OpenData> _realDataObservable = new ObservableCollection<OpenData>();
        /// <summary>
        /// 營建署所屬景點活動清單
        /// </summary>
        public ObservableCollection<OpenData> RealDataObservable
        {
            get { return _realDataObservable; }
            set { SetProperty(ref _realDataObservable, value); }
        }
        #endregion

        public MainPageViewModel()
        {

        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
            var client = new System.Net.Http.HttpClient();
            var data = await client.GetStringAsync("http://www.cpami.gov.tw/opendata/events_json.php");
            var realData = Newtonsoft.Json.JsonConvert.DeserializeObject<OpenData[]>(data);

            foreach(var eachData in realData)
            {
                RealDataObservable.Add(eachData);
            }
            
        }
    }

    public class OpenData
    {
        public string id { get; set; }
        public string orgname { get; set; }
        public string startdate { get; set; }
        public string enddate { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string location { get; set; }
        public string contact { get; set; }
        public string extraurl { get; set; }
        public string created { get; set; }
        public string introtext { get; set; }
    }

}
