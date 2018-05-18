using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using ReactiveUI.AndroidSupport;
using Viewer.ViewModels;
using Viewer.Droid.Views;
using Viewer.Droid.Helpers;




namespace Viewer.Droid
{
    [Activity(Label = "Viewer", Icon = "@drawable/icon",  MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity:ReactiveAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            Bootstrapper.Initialize();
            BootstraperDroid.Initialize();

            base.OnCreate(bundle);

            SetContentView(Resource.Layout.First);

            var mainFragment = new MainFragment()
            {
                ViewModel = new MainViewModel()
            };
           
            this.NextFragment(Resource.Id.frame, mainFragment);
        }
    }
}

