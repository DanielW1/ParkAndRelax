using System;
using System.Collections.Generic;
using System.Text;
using Splat;
using ReactiveUI;
using Viewer.Services;

namespace Viewer
{
    public class Bootstrapper
    {
        public static void Initialize()
        {
            Locator.CurrentMutable.RegisterConstant<IConvertingjsonService>(new ConvertingJsonService("ParkRideData.json"));
        }
    }
}