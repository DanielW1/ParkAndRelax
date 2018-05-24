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
using Android.Support.V7.Widget;
using Android.Support.V7.RecyclerView;

namespace Viewer.Droid
{
    [Activity(Label = "Viewer",
        MainLauncher = true,
        Theme = "@style/MainTheme",
        Icon = "@drawable/icon",

        ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]
    public class MainActivity : ReactiveAppCompatActivity

    {

        private RecyclerView recycler_view;
        private RecyclerView.LayoutManager mLayoutManager;
        private RecyclerView.Adapter mAdapter;
        private List<Event> mEvents;

        protected override void OnCreate(Bundle bundle)
        {
            BootstraperDroid.Initialize();
            Bootstrapper.Initialize();

            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);
           /* 
            recycler_view = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            List<Event> lstsource = new List<Event>();
            for (int i = 0; i < 5; i++)
            {
                Event evencik = new Event()
                {
                    Name = "James" + i,
                    Date = "23.05.12" + i,
                    Place = "Warszawa" + i,
                    Price = "12 zł" + i,
                };
                lstsource.Add(evencik);
            }*/
            /*
            mLayoutManager = new LinearLayoutManager(this);
            recycler_view.SetLayoutManager(mLayoutManager);
            mAdapter = new ListAdapter(lstsource);
            recycler_view.SetAdapter(mAdapter);*/

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
