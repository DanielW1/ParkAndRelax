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
using Android.Support.V7.Widget;
using Android.Support.V7.RecyclerView;
using Splat;
using Viewer.Services;
using System.Threading.Tasks;
using System.Reactive;
using System.Reactive.Disposables;

namespace Viewer.Droid.Views
{
    public class EventsListFragment : ReactiveUI.AndroidSupport.ReactiveFragment<EventsListViewModel>
    {
        private RecyclerView recycler_view;
        private RecyclerView.LayoutManager mLayoutManager;
        private RecyclerView.Adapter mAdapter;
        private List<Event> mEvents;
        List<Event> lstsource = new List<Event>();
        IGeoLocationService reqservice = Locator.CurrentMutable.GetService<IGeoLocationService>();
        View view;
        Button buttonChoose;

        public EventsListFragment(List<Event> events)
        {
            mEvents = events;
            this.WhenActivated(disposable =>
            {


                ViewModel.SwitchToMap.Subscribe(mapViewModel =>
                {
                    var mapFragment = new MapFragment(52.2162198, 21.0144244, "Polska dla Polaków", "Tutaj można wszystko")
                    {
                        ViewModel = mapViewModel
                    };
                    Activity.NextFragment(Resource.Id.frame, mapFragment);
                });

                recycler_view.Events().Click.Select(_ => Unit.Default).InvokeCommand(this, x => x.ViewModel.SwitchToMap).DisposeWith(disposable);
                buttonChoose.Events().Click.Select(_ => Unit.Default).InvokeCommand(this, x => x.ViewModel.SwitchToMap).DisposeWith(disposable);
                
            });
        }


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

     
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.fragment_eventsList,container, false);

            recycler_view = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);
            buttonChoose = view.FindViewById<Button>(Resource.Id.buttonChoose);

            /*  List<Event> lstsource = new List<Event>();
              for (int i = 0; i < 20; i++)
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

            mLayoutManager = new LinearLayoutManager(Activity);
            recycler_view.SetLayoutManager(mLayoutManager);
            mAdapter = new ListAdapter(mEvents);
            recycler_view.SetAdapter(mAdapter);

            return view;
        }
       
        
    
}
}