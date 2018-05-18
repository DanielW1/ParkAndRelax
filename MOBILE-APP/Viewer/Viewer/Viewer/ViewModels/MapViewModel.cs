using System;
using System.Collections.Generic;
using Viewer.Models;
using ReactiveUI;
using Splat;
using Viewer.Services;
using System.Reactive.Linq;
using System.Reactive.Disposables;

namespace Viewer.ViewModels
{
    public class MapViewModel : ReactiveViewModel
    {
        private List<ParkRide> _parkAndRides;
        public List<ParkRide> ParkandRides
        {
            get => _parkAndRides;
            set => this.RaiseAndSetIfChanged(ref _parkAndRides, value);
        }
        public MapViewModel()
        {

            this.WhenActivated(disposable=>
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