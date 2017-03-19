using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListViewPractice_01_Basic.ViewModels
{
    public class StudentDataPageViewModel : BindableBase, INavigationAware
    {
        private Student _student;
        public Student Student
        {
            get { return _student; }
            set { SetProperty(ref _student, value); }
        }

        private string _stuNam;
        public string StuNam
        {
            get { return _stuNam; }
            set { SetProperty(ref _stuNam, value); }
        }

        public DelegateCommand SendNewStudendNameCommand { get; set; }


        public StudentDataPageViewModel(IEventAggregator eventAggregator, INavigationService navigationService)
        {
            this.SendNewStudendNameCommand = new DelegateCommand(() =>
            {
                eventAggregator.GetEvent<StudentDataUpdatedEvent>().Publish(new Student()
                {
                    StuNum = this._student.StuNum,
                    StuNam = StuNam
                });
                navigationService.GoBackAsync();
            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            this._student = parameters["student"] as Student;
            StuNam = this._student.StuNam;
        }

    }
}
