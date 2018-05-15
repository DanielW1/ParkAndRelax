using System;
using System.Collections.Generic;
using System.Text;
using Splat;
using ReactiveUI;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Viewer.Services;
using Viewer.Models;


namespace Viewer.ViewModels
{
    public class MapViewModel: ReactiveViewModel
    {
        private List<ParkRide> _parkAndRides;
        public List<ParkRide> ParkandRides
        {
            get => _parkAndRides;
            set => this.RaiseAndSetIfChanged(ref _parkAndRides, value);
        }
        public MapViewModel()
        {

            this.WhenActivated((CompositeDisposable disposable) =>
            {
                IConvertingjsonService service = Locator.CurrentMutable.GetService<IConvertingjsonService>();

                Observable.FromAsync(_ => service.GetAllParkings()).Subscribe(parkingList =>
                {
                    ParkandRides = parkingList;
                }).DisposeWith(disposable);

            });
        }
    }
}
