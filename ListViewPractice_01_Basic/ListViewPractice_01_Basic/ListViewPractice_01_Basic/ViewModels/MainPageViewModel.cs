using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ListViewPractice_01_Basic.ViewModels
{
    public class Student : BindableBase
    {
        public string StuNum { get; set; }

        private string _stuNam;
        public string StuNam
        {
            get { return _stuNam; }
            set { SetProperty(ref _stuNam, value); }
        }
    }

    public class MainPageViewModel : BindableBase, INavigationAware
    {

        private Student _selectedStudent;
        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set { SetProperty(ref _selectedStudent, value); }
        }

        private ObservableCollection<Student> _students;
        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set { SetProperty(ref _students, value); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand StudentItemTappedCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            _students = new ObservableCollection<Student>();
            for (int i = 0; i < 100; ++i)
            {
                _students.Add(new Student()
                {
                    StuNum = i.ToString("00000"),
                    StuNam = String.Format("Student_{0}", i)
                });
            }

            StudentItemTappedCommand = new DelegateCommand(async () =>
            {
                NavigationParameters param = new NavigationParameters();
                param.Add("student", SelectedStudent);
                await navigationService.NavigateAsync("StudentDataPage", param);
            });

            eventAggregator.GetEvent<StudentDataUpdatedEvent>().Subscribe((Student student) =>
            {
                var targetStudent = this.Students.First(stu => stu.StuNum == student.StuNum);
                targetStudent.StuNam = student.StuNam;
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
