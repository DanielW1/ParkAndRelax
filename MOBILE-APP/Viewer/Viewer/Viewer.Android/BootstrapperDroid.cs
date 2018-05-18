using System;
using Splat;
using Viewer.Services;
using Viewer.Droid.Helpers;
using ReactiveUI;

namespace Viewer
{
    class BootstraperDroid
    {
        public static void Initialize()
        {
            Locator.CurrentMutable.RegisterConstant<IAssetReader>(new ReadFileFromAssetsDroid());
             
        }
    }
}