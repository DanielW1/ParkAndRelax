using Viewer.ViewModels;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using ReactiveUI;
using Splat;
using Viewer.Services;
using Android.OS;
using Android.Views;
using System;
using Android.Widget;
using Viewer.Droid.Helpers;

namespace Viewer.Droid.Views
{
    public class MainFragment:ReactiveUI.AndroidSupport.ReactiveFragment<MainViewModel>
    {
        Button _dateButton;
        Button _eventButton;
        public MainFragment()
        {
            this.WhenActivated(disposable =>
            {
                ViewModel.SwitchToDate.Subscribe(dateViewModel =>
                {
                    var dateFragment = new DateFragment()
                    {
                        ViewModel = dateViewModel
                    };
                    Activity.NextFragment(Resource.Id.frame, dateFragment);
                });

                ViewModel.SwitchToEvent.Subscribe(eventViewModel =>
                {
                    var eventFragment = new EventFragment()
                    {
                        ViewModel = eventViewModel
                    };
                    Activity.NextFragment(Resource.Id.frame, eventFragment);
                });

                _eventButton.Events().Click.Select(_ => Unit.Default).InvokeCommand(this, x => x.ViewModel.SwitchToEvent);
                _dateButton.Events().Click.Select(_ => Unit.Default).InvokeCommand(this, x => x.ViewModel.SwitchToDate);
            });
           
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.First, container, false);
            _eventButton = view.FindViewById<Button>(Resource.Id.eventButton);
            _dateButton = view.FindViewById<Button>(Resource.Id.dateButton);

            return view;

        }

       
    }
}