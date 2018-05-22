using ReactiveUI;
using System.Reactive;


namespace Viewer.ViewModels
{
    public class MainViewModel : ReactiveViewModel
    {
        public MainViewModel()
        {

                SwitchToDate = ReactiveCommand.Create<Unit, DateViewModel>(_ => new DateViewModel());
                SwitchToEvent = ReactiveCommand.Create<Unit, EventViewModel>(_ => new EventViewModel());
         

        }

        public ReactiveCommand <Unit,EventViewModel> SwitchToEvent { get; private set; }
        public ReactiveCommand <Unit,DateViewModel> SwitchToDate { get; private set; }
    }
}
