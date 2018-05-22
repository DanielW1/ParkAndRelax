using ReactiveUI;
using System.Reactive;
using System.Reactive.Disposables;

namespace Viewer.ViewModels
{
    public class DateViewModel : ReactiveViewModel
    {
        public DateViewModel()
        {
            this.WhenActivated((CompositeDisposable disposable) =>
            {

            });
            SwitchToEventsList = ReactiveCommand.Create<Unit, EventsListViewModel>(_ => new EventsListViewModel());
        }

        public ReactiveCommand<Unit, EventsListViewModel> SwitchToEventsList { get; }
        

        
    }
}
