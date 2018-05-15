using System;
using ReactiveUI;
using Splat;
using Viewer.Services;
using Viewer.Droid.Helpers;


namespace Viewer.Droid
{
    class BootstraperDroid
    {
        public static void Initialize()
        {
            Locator.CurrentMutable.RegisterConstant<IAssetReader>(new ReadFileFromAssetsDroid());
        }
    }
}