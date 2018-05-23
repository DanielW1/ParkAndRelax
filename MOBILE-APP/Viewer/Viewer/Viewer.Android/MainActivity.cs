using System;
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
            
            /*var list = FindViewById<ListView>(Resource.Id.listView);
            List<Event> lstsource = new List<Event>();
            for (int i = 0; i < 5; i++)
            {
                Event evencik = new Event()
                {
                    Id = i,
                    Name = "James" + i,
                    Date = "23.05.12" + i,
                    Place = "Warszawa" + i,
                    Price = "12 zł" + i,
                    Category = "POP" + i
                };
                lstsource.Add(evencik);
            }

            list.Adapter = new CustomAdapter(this, lstsource);*/
        }
    }
}
