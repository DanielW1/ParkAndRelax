using System;
using System.Collections.Generic;
using System.Text;
using Splat;
using ReactiveUI;
using Viewer.Services;

namespace Viewer
{
    class Bootstraper
    {
        public static void Initialize()
        {
            Locator.CurrentMutable.RegisterConstant<IConvertingjsonService>(new ConvertingJsonService("path"));
        }
    }
}
