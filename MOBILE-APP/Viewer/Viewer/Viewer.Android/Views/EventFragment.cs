using Viewer.ViewModels;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using ReactiveUI;
using Android.OS;
using Android.Views;
using System;
using Android.Widget;
using Viewer.Droid.Helpers;
using Viewer.Services;
using Viewer.Models;

namespace Viewer.Droid.Views
{
    public class EventFragment : ReactiveUI.AndroidSupport.ReactiveFragment<EventViewModel>
    {
        Button _lectureButton;
        Button _concertButton;
        Button _theatreButton;
        Button _orchestraButton;
        Button _meetingButton;

        public string category { get; set; }
        public EventFragment()
        {

            this.WhenActivated((CompositeDisposable disposable) =>
            {
                ViewModel.SwitchToEventsList.Subscribe(EventsListViewModel =>
                {
                    var eventListFragment = new EventsListFragment("Koncert") { ViewModel = EventsListViewModel };
                    Activity.NextFragment(Resource.Id.frame, eventListFragment);
                }
                ).DisposeWith(disposable);

                _lectureButton.Events().Click.Select(_ => Unit.Default).InvokeCommand(this, x => x.ViewModel.SwitchToEventsList);
                _concertButton.Events().Click.Select(_ => Unit.Default).InvokeCommand(this, x => x.ViewModel.SwitchToEventsList);
                _theatreButton.Events().Click.Select(_ => Unit.Default).InvokeCommand(this, x => x.ViewModel.SwitchToEventsList);
                _orchestraButton.Events().Click.Select(_ => Unit.Default).InvokeCommand(this, x => x.ViewModel.SwitchToEventsList);
                _meetingButton.Events().Click.Select(_ => Unit.Default).InvokeCommand(this, x => x.ViewModel.SwitchToEventsList);

                //_lectureButton.Events().Click.Subscribe(result => restClient.Get<Event>("http://localhost:644988/Events/search?name=moje")

                //).DisposeWith(disposable);
            });
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.fragment_event, container, false);

            _lectureButton = view.FindViewById<Button>(Resource.Id.lectureButton);
            _concertButton = view.FindViewById<Button>(Resource.Id.concertButton);
            _theatreButton = view.FindViewById<Button>(Resource.Id.theatreButton);
            _orchestraButton = view.FindViewById<Button>(Resource.Id.orchestraButton);
            _meetingButton = view.FindViewById<Button>(Resource.Id.meetingButton);

            return view;
        }

        /*public async override void SendRequest()
        {
            var result = await client.Get
        }*/
    }


}
