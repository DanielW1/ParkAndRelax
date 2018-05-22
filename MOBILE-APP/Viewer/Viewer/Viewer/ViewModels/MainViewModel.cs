using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using System.Reactive;
using System.Reactive.Disposables;

namespace Viewer.ViewModels
{
    public class MainViewModel:ReactiveViewModel
    {
        public MainViewModel()
        {
            
            this.WhenActivated((CompositeDisposable disposable) =>
            {

            });
            SwitchToDate = ReactiveCommand.Create<Unit, DateViewModel>(_ => new DateViewModel());
            SwitchToEvent = ReactiveCommand.Create<Unit, EventViewModel>(_ => new EventViewModel());
           
          
        }

        public ReactiveCommand<Unit,EventViewModel> SwitchToEvent { get; }
        public ReactiveCommand<Unit,DateViewModel> SwitchToDate { get; }
    }
}
