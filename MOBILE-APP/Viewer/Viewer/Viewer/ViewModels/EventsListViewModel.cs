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
    public class EventsListViewModel : ReactiveViewModel
    {

        private EventOnMapModel _eventOnMapModel;
        
        public EventOnMapModel EventOnMapModel
        {
            get => _eventOnMapModel;
            set => this.RaiseAndSetIfChanged(ref _eventOnMapModel, value);
        }

        private List<Event> _eventsList;
        public List<Event> EventsList
        {
            get => _eventsList;
            set => this.RaiseAndSetIfChanged(ref _eventsList, value);
        }
        
        public EventsListViewModel( )
        {
            this.WhenActivated((CompositeDisposable disposable) =>
            {
                SwitchToMap = ReactiveCommand.Create<Unit, MapViewModel>(_ => new MapViewModel());
            });
        }
        public ReactiveCommand<Unit, MapViewModel> SwitchToMap { get; private set; }


    }
}
