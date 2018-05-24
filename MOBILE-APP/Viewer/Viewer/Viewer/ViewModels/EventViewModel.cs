using ReactiveUI;
using System.Reactive;
using System.Reactive.Disposables;


namespace Viewer.ViewModels
{
    public class EventViewModel : ReactiveViewModel
    {
        public string Category;
        public EventViewModel()
        {
            this.WhenActivated((CompositeDisposable disposable) =>
            {

            });
            SwitchToEventsListMeeting = ReactiveCommand.Create<Unit, BetweenViewModel>(_ => new BetweenViewModel("Spotkanie"));
            SwitchToEventsListTheatre = ReactiveCommand.Create<Unit, BetweenViewModel>(_ => new BetweenViewModel("Teatr"));
            SwitchToEventsListOrchestra = ReactiveCommand.Create<Unit, BetweenViewModel>(_ => new BetweenViewModel("Orkiestra"));
            SwitchToEventsListLecture = ReactiveCommand.Create<Unit, BetweenViewModel>(_ => new BetweenViewModel("Wykład"));
            SwitchToEventsListConcert = ReactiveCommand.Create<Unit, BetweenViewModel>(_ => new BetweenViewModel("Koncert"));
            
        }
        
       
        public ReactiveCommand <Unit, BetweenViewModel> SwitchToEventsListMeeting { get; private set; }
        public ReactiveCommand <Unit, BetweenViewModel> SwitchToEventsListTheatre { get; private set; }
        public ReactiveCommand <Unit, BetweenViewModel> SwitchToEventsListOrchestra { get; private set; }
        public ReactiveCommand <Unit, BetweenViewModel> SwitchToEventsListLecture { get; private set; }
        public ReactiveCommand <Unit, BetweenViewModel> SwitchToEventsListConcert { get; private set; }
    
    }
}
