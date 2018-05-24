using ReactiveUI;
using System.Reactive;

namespace Viewer.ViewModels
{
    public class DateViewModel : ReactiveViewModel
    {
        public DateViewModel()
        {
                SwitchToEventsListFromEvent = ReactiveCommand.Create<Unit, BetweenViewModel>(_ => new BetweenViewModel("Koncert"));
        }

        public ReactiveCommand<Unit, BetweenViewModel> SwitchToEventsListFromEvent { get; private set; }
        
    }
}
