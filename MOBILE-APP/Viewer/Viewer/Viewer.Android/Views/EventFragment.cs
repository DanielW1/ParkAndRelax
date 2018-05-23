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
        private string concert = "Koncert";
        private string orchestra = "Orkiestra";
        private string meeting = "Spotkanie";
        private string theatre = "Teatr";
        private string lecture = "Wykład";

        public string Category { get; set; }
     
        public EventFragment()
        {

            this.WhenActivated((CompositeDisposable disposable) =>
            {
                ViewModel.SwitchToEventsList.Subscribe(EventsListViewModel =>
                {
                    var eventListFragment = new EventsListFragment() { ViewModel = EventsListViewModel };
                    Activity.NextFragment(Resource.Id.frame, eventListFragment);
                }
                ).DisposeWith(disposable);

                _lectureButton.Events().Click.Select(_ => SetCategory(lecture)).InvokeCommand(this,
                    x => x.ViewModel.SwitchToEventsList).DisposeWith(disposable);

                _concertButton.Events().Click.Select(x => SetCategory(concert)).InvokeCommand(this, x => x.ViewModel.SwitchToEventsList).DisposeWith(disposable);
                _theatreButton.Events().Click.Select(x => SetCategory(theatre)).InvokeCommand(this, x => x.ViewModel.SwitchToEventsList).DisposeWith(disposable);
                _orchestraButton.Events().Click.Select(x => SetCategory(orchestra)).InvokeCommand(this, x => x.ViewModel.SwitchToEventsList).DisposeWith(disposable);
                _meetingButton.Events().Click.Select(x => SetCategory(meeting)).InvokeCommand(this, x => x.ViewModel.SwitchToEventsList).DisposeWith(disposable);
                _meetingButton.Events().Click.Select(x => SetCategory(meeting)).InvokeCommand(this, x => x.ViewModel.SwitchToEventsList).DisposeWith(disposable);

                
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
                Category = "Koncert";
            }
            else if (category == "Wykład")
            {
                Category = "Wykład";
            }
            else if (category == "Orkiestra")
            {
                Category = "Orkiestra";
            }
            else if (category == "Spotkanie")
            {
                Category = "Spotkanie";
            }
            else if(category == "Teatr")
            {
                Category = "Teatr";
            }

            return Category;
        }
    }


}
