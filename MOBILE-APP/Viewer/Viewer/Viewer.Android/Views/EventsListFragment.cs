using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using ReactiveUI;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Viewer.ViewModels;
using Viewer.Droid.Helpers;
using Viewer.Models;

namespace Viewer.Droid.Views
{
    public class EventsListFragment : ReactiveUI.AndroidSupport.ReactiveFragment<EventsListViewModel>
    {
        public EventsListFragment()
        {
            this.WhenActivated(disposable =>
            {/*
                ViewModel.SwitchToMap.Subscribe(mapViewModel =>
                {
                    var mapFragment = new MapFragment(52.2162198, 21.0144244, "Polska dla Polaków", "Tutaj można wszystko")
                    {
                        ViewModel = mapViewModel
                    };
                    Activity.NextFragment(Resource.Id.frame, mapFragment);
                });
                */

            });
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_eventsList,container, false);

            //var list = view.FindViewById<ListView>(Resource.Id.listView);
            List<Event> lstsource = new List<Event>();
            for(int i = 0; i<5; i++)
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
          
            //list.Adapter = new CustomAdapter(Application.Context, lstsource);

            return View;
        }
    }
}