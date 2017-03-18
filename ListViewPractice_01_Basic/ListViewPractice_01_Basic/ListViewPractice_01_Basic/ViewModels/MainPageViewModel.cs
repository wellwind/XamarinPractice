using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ListViewPractice_01_Basic.ViewModels
{
    public class Student
    {
        public string StuNum { get; set; }
        public string StuNam { get; set; }
    }

    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private ObservableCollection<Student> _students;
        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set { _students = value; SetProperty(ref _students, value); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainPageViewModel()
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
