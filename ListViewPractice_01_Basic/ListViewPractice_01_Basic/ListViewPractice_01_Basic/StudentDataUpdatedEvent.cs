using ListViewPractice_01_Basic.ViewModels;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewPractice_01_Basic
{
    public class StudentDataUpdatedEvent : PubSubEvent<Student>
    {
    }
}
