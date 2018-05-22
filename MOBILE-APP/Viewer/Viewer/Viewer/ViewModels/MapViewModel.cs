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

        private EventOnMapModel _eventOnMapModel;
        public EventOnMapModel EventOnMapModel {
            get => _eventOnMapModel;
            set => this.RaiseAndSetIfChanged(ref _eventOnMapModel, value);

        }
        public MapViewModel()
        {
            this.WhenActivated(disposable=>
            {
                IConvertingjsonService service = Locator.CurrentMutable.GetService<IConvertingjsonService>();
                IGeoLocationService geoservice = Locator.CurrentMutable.GetService<IGeoLocationService>();

                Observable.FromAsync(_ => service.GetAllParkings())
                .Select(async parkings =>
                {
                    ParkandRides = parkings;
                    var eventLatLng = await geoservice.GetLatitudeandLongtitude("Riviera");
                    EventOnMapModel.Latitude = eventLatLng.latitude;
                    EventOnMapModel.Longtitude = eventLatLng.longtitude;
                    System.Diagnostics.Debug.WriteLine("Latitude" + eventLatLng.latitude.ToString());
                })
                .Subscribe()
                .DisposeWith(disposable);
            });
        }
    }
}