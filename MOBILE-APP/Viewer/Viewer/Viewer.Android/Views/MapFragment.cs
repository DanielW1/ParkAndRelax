using Android.App;
using Android.Gms.Maps;
using Android.OS;
using Android.Views;
using ReactiveUI;
using Viewer.Models;
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

        public void OnMapReady(GoogleMap googleMap)
        {
            GoogleMap = googleMap;
        }
    }
}