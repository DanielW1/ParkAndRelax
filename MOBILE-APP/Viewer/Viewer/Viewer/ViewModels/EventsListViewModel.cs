using ReactiveUI;
using Splat;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Viewer.Models;
using Viewer.Services;
using System;
using System.Reactive;

namespace Viewer.ViewModels
{
    public class EventsListViewModel: ReactiveViewModel
    {

        private List<Event> _eventsList;
        public List<Event> EventsList
        {
            get => _eventsList;
            set => this.RaiseAndSetIfChanged(ref _eventsList, value);
        }
        IGeoLocationService reqservice = Locator.CurrentMutable.GetService<IGeoLocationService>();
        public EventsListViewModel()
        {
            this.WhenActivated((CompositeDisposable disposable) =>
            {

                Observable.FromAsync(_ => reqservice.Get()).Subscribe(listofevents =>
                {
                    EventsList = listofevents;
                });
            });

        }

        public ReactiveCommand<Unit, MapViewModel> SwitchToMap { get; private set; }
    }
}
