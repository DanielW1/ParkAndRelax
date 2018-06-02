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
        Button _sendButton;
        private string concert = "Koncert";
        private string orchestra = "Orkiestra";
        private string meeting = "Spotkanie";
        private string theatre = "Teatr";
        private string lecture = "Wykład";



        public EventFragment()
        {

            this.WhenActivated((CompositeDisposable disposable) =>
            {
                ViewModel.SwitchToEventsListConcert.Subscribe(EventsListViewModel =>
                {
                    var eventListFragment = new BetweenFragment() { ViewModel = EventsListViewModel };
                    Activity.NextFragment(Resource.Id.frame, eventListFragment);
                }).DisposeWith(disposable);

                ViewModel.SwitchToEventsListTheatre.Subscribe(EventsListViewModel =>
                {
                    var eventListFragment = new BetweenFragment() { ViewModel = EventsListViewModel };
                    Activity.NextFragment(Resource.Id.frame, eventListFragment);
                }).DisposeWith(disposable);

                ViewModel.SwitchToEventsListOrchestra.Subscribe(EventsListViewModel =>
                {
                    var eventListFragment = new BetweenFragment() { ViewModel = EventsListViewModel };
                    Activity.NextFragment(Resource.Id.frame, eventListFragment);
                }).DisposeWith(disposable);

                ViewModel.SwitchToEventsListMeeting.Subscribe(EventsListViewModel =>
                {
                    var eventListFragment = new BetweenFragment() { ViewModel = EventsListViewModel };
                    Activity.NextFragment(Resource.Id.frame, eventListFragment);
                }).DisposeWith(disposable);

                ViewModel.SwitchToEventsListLecture.Subscribe(EventsListViewModel =>
                {
                    var eventListFragment = new BetweenFragment() { ViewModel = EventsListViewModel };
                    Activity.NextFragment(Resource.Id.frame, eventListFragment);
                }).DisposeWith(disposable);

                _concertButton.Events().Click.Select(_ => Unit.Default).InvokeCommand(this, x => x.ViewModel.SwitchToEventsListConcert).DisposeWith(disposable);
                _meetingButton.Events().Click.Select(_ => Unit.Default).InvokeCommand(this, x => x.ViewModel.SwitchToEventsListMeeting).DisposeWith(disposable);
                _theatreButton.Events().Click.Select(_ => Unit.Default).InvokeCommand(this, x => x.ViewModel.SwitchToEventsListTheatre).DisposeWith(disposable);
                _orchestraButton.Events().Click.Select(_ => Unit.Default).InvokeCommand(this, x => x.ViewModel.SwitchToEventsListOrchestra).DisposeWith(disposable);
                _lectureButton.Events().Click.Select(_ => Unit.Default).InvokeCommand(this, x => x.ViewModel.SwitchToEventsListLecture).DisposeWith(disposable);
        
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

        private string SetCategory(String category)
        {
            if (category == "Koncert")
            {
                ViewModel.Category = "Koncert";
            }
            else if (category == "Wykład")
            {
                ViewModel.Category = "Wykład";
            }
            else if (category == "Orkiestra")
            {
                ViewModel.Category = "Orkiestra";
            }
            else if (category == "Spotkanie")
            {
                ViewModel.Category = "Spotkanie";
            }
            else if (category == "Teatr")
            {
                ViewModel.Category = "Teatr";
            }

            return ViewModel.Category;
        }
    }


}
