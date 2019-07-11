using CompressedVideoDemo.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CompressedVideoDemo.DS
{
    public class Dependency_Services
    {
        public static IMobileFeature MobileFeature
        {
            get
            {
                return DependencyService.Get<IMobileFeature>(DependencyFetchTarget.GlobalInstance);
            }
        }
    }
}
