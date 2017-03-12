using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPractice
{
    public class SayHelloEvent : Prism.Events.PubSubEvent<string>
    {
    }
}
