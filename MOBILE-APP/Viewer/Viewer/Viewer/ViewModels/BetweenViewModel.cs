using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;
using Viewer.Services;
using Viewer.Models;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading;

namespace Viewer.ViewModels
{
    public class BetweenViewModel:ReactiveViewModel
    {
        private List<Event> _eventsList;
        public List<Event> EventsList
        {
            get => _eventsList;
            set => this.RaiseAndSetIfChanged(ref _eventsList, value);
        }
        IGeoLocationService reqservice = Locator.CurrentMutable.GetService<IGeoLocationService>();
        public BetweenViewModel(string category)
        {
            SwitchToEventsListFromBetween = ReactiveCommand.Create<Unit, EventsListViewModel>(_ => new EventsListViewModel());

            this.WhenActivated((CompositeDisposable disposable) =>
            {
                         Observable.FromAsync(_ => reqservice.GetAllEvents(category)).Subscribe(events =>
                      {
                          EventsList = events;
                      }
                      );
                Thread.Sleep(4000);
            });
        }
        public ReactiveCommand <Unit, EventsListViewModel> SwitchToEventsListFromBetween { get; private set; }
    }
}
