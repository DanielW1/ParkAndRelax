﻿using System;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Viewer.Droid.Views;
using Viewer.ViewModels;
using Viewer.Droid.Helpers;
using ReactiveUI.AndroidSupport;
using Android.Widget;
using System.Collections.Generic;
using Viewer.Models;

namespace Viewer.Droid
{
    [Activity(Label = "Viewer",
        MainLauncher = true,
        Theme = "@style/MainTheme",
        Icon = "@drawable/icon",

        ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]
    public class MainActivity : ReactiveAppCompatActivity

    {
        protected override void OnCreate(Bundle bundle)
        {
            BootstraperDroid.Initialize();
            Bootstrapper.Initialize();

            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

           
            var mainFragment = new MainFragment(){ ViewModel = new MainViewModel()};
            this.NextFragment(Resource.Id.frame, mainFragment);
            
           
        }

        public override void OnBackPressed()
        {
             if(SupportFragmentManager.BackStackEntryCount == 1)
            {
                Finish();
            }
            else
            {
                if(SupportFragmentManager.BackStackEntryCount > 1)
                {
                    SupportFragmentManager.PopBackStackImmediate();
                }
            }
        }
    }
}
