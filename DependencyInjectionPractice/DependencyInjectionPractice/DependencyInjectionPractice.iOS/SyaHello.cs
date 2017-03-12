using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Prism.Unity;
using Microsoft.Practices.Unity;

[assembly: Xamarin.Forms.Dependency(typeof(DependencyInjectionPractice.iOS.SayHello))]
namespace DependencyInjectionPractice.iOS
{
    public class SayHello : ISayHello
    {
        public string Hello()
        {
            return "iOS";
        }
    }
}