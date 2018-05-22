using ReactiveUI;
using System.Reactive;

namespace Viewer.ViewModels
{
    public class DateViewModel : ReactiveViewModel
    {
        public DateViewModel()
        {
                SwitchToEventsListFromEvent = ReactiveCommand.Create<Unit, EventsListViewModel>(_ => new EventsListViewModel());
        }

        public ReactiveCommand<Unit, EventsListViewModel> SwitchToEventsListFromEvent { get; private set; }
        
    }
}
