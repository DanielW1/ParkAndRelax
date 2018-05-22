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

namespace Viewer.Droid.Views
{
    public class EventsListFragment : ReactiveUI.AndroidSupport.ReactiveFragment<EventsListViewModel>
    {
        public EventsListFragment()
        {
            this.WhenActivated(disposable =>
            {
                ViewModel.SwitchToMap.Subscribe(mapViewModel =>
                {
                    var mapFragment = new MapFragment(52.2162198, 21.0144244, "Polska dla Polaków", "Tutaj można wszystko")
                    {
                        ViewModel = mapViewModel
                    };
                });


            });
        }
    }
}