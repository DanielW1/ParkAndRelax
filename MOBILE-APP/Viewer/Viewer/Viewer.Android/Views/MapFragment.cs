using Android.App;
using Android.Gms.Maps;
using Android.OS;
using Android.Views;
using ReactiveUI;
using Android.Gms.Maps.Model;
using System.Reactive.Linq;
using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Android.Locations;
using Android.Content;
using System.Threading;
using System.Linq;
using System.IO;
using Viewer.ViewModels;


namespace Viewer.Droid.Views
{
    class MapFragment : ReactiveUI.AndroidSupport.ReactiveFragment<MapViewModel>, IOnMapReadyCallback
    {
        private SupportMapFragment _mapFragment;
        private GoogleMap _googleMap;
        private GoogleMap GoogleMap
        {
            get => _googleMap;
            set => this.RaiseAndSetIfChanged(ref _googleMap, value);
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.fragment_map, container, false);


            var mapOptions = new GoogleMapOptions()
                .InvokeMapType(GoogleMap.MapTypeNormal)
                .InvokeZoomControlsEnabled(false)
                .InvokeCompassEnabled(true);

            var fragTx = FragmentManager.BeginTransaction();
            _mapFragment = SupportMapFragment.NewInstance(mapOptions);
            fragTx.Add(Resource.Id.map, _mapFragment, "map");
            fragTx.Commit();

            _mapFragment.GetMapAsync(this);
            return view;
        }

        public MapFragment(double latitude, double longtitude, string title, string description)
        {
            this.WhenActivated(disposable =>
            {
                this.WhenAnyValue(z => z.ViewModel.ParkandRides, z=> z.GoogleMap)
                .Where(z => z.Item1?.Count > 0 && z.Item2 != null)
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(data =>
                {
                    
                    foreach (var parking in data.Item1)
                    {
                        data.Item2.AddMarker(new MarkerOptions()
                            .SetPosition(new LatLng(parking.Latitude, parking.Longtitude))
                            .SetTitle(parking.Place)
                            .SetSnippet(parking.Location));
                        System.Diagnostics.Debug.WriteLine(parking.Id);
                    }

                    var marker = data.Item2.AddMarker(new MarkerOptions()
                   .SetPosition(new LatLng(latitude, longtitude))
                   .SetTitle(title)
                   .SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.@event))
                   .SetSnippet(description));

                    var location = new LatLng(latitude, longtitude);
                    var builder = CameraPosition.InvokeBuilder();
                    builder.Target(location);
                    builder.Zoom(12);
                    var cameraPosition = builder.Build();
                    var cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);
                    _googleMap.MoveCamera(cameraUpdate);

                }).DisposeWith(disposable);

                
               
            });
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            GoogleMap = googleMap;
        }

        

       
    }
}