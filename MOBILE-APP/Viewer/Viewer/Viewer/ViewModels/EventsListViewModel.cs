using ReactiveUI;
using System.Reactive;
using System.Reactive.Disposables;

namespace Viewer.ViewModels
{
    public class EventsListViewModel: ReactiveViewModel
    {
        public EventsListViewModel()
        {
   
            this.WhenActivated((CompositeDisposable disposable) =>
            {
                SwitchToMap = ReactiveCommand.Create<Unit, MapViewModel>(_ => new MapViewModel());
            });
           
        }

        public ReactiveCommand<Unit, MapViewModel> SwitchToMap { get; private set; }
    }
}
