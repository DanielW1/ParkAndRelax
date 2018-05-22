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
    public class EventFragment: ReactiveUI.AndroidSupport.ReactiveFragment<EventViewModel>
    {
        Button _lectureButton;
        Button _concertButton;
        Button _theatreButton;
        Button _orchestraButton;
        Button _meetingButton;


        public EventFragment()
        {
            this.WhenActivated(disposable =>
            {
                ViewModel.SwitchToEventsList.Subscribe(eventsListViewModel =>
                {
                    var eventslistFragment = new EventsListFragment()
                    {
                        ViewModel = eventsListViewModel
                    };
                });

                _lectureButton.Events().Click.Select(_ => Unit.Default).InvokeCommand(this, x => x.ViewModel.SwitchToEventsList);
                _concertButton.Events().Click.Select(_ => Unit.Default).InvokeCommand(this, x => x.ViewModel.SwitchToEventsList);
                _theatreButton.Events().Click.Select(_ => Unit.Default).InvokeCommand(this, x => x.ViewModel.SwitchToEventsList);
                _orchestraButton.Events().Click.Select(_ => Unit.Default).InvokeCommand(this, x => x.ViewModel.SwitchToEventsList);
                _meetingButton.Events().Click.Select(_ => Unit.Default).InvokeCommand(this, x => x.ViewModel.SwitchToEventsList);

            });

        }


    }
}