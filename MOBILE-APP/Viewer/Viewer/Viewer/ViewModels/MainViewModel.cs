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
            SwitchToMap = ReactiveCommand.Create<Unit, MapViewModel>(_ => new MapViewModel());
            this.WhenActivated((CompositeDisposable disposable) =>
            {

            });
        }
        public ReactiveCommand<Unit,MapViewModel> SwitchToMap { get; }
    }
}
