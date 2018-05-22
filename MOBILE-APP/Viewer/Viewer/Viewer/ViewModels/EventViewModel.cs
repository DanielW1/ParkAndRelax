using ReactiveUI;
using System.Reactive;
using System.Reactive.Disposables;

namespace Viewer.ViewModels
{
    public class EventViewModel : ReactiveViewModel
    {
        public EventViewModel()
        {
            this.WhenActivated((CompositeDisposable disposable) =>
            {

            });
                  SwitchToEventsList = ReactiveCommand.Create<Unit, EventsListViewModel>(_ => new EventsListViewModel());

        }

        public ReactiveCommand <Unit, EventsListViewModel> SwitchToEventsList { get; private set; }

    }
}
