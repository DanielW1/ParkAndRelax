using Viewer.ViewModels;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using ReactiveUI;
using Splat;
using Viewer.Services;
using Android.OS;
using Android.Views;
using System;
using Android.Widget;
using Viewer.Droid.Helpers;

namespace Viewer.Droid.Views
{
    public class MainFragment:ReactiveUI.AndroidSupport.ReactiveFragment<MainViewModel>
    {
        Button _concertButton;
        Button lectureButton;
        public MainFragment()
        {
            this.WhenActivated(disposable =>
            {
                ViewModel.SwitchToMap.Subscribe(MapViewModel =>
                {

                    var mapFragment = new MapFragment(52.2162198, 21.0144244, "Polska dla Polaków","Tutaj można wszystko")
                    {
                        ViewModel = MapViewModel
                    };
                    Activity.NextFragment(Resource.Id.frame, mapFragment);
                });
                _concertButton.Events().Click.Select(_ => Unit.Default).InvokeCommand(this, x => x.ViewModel.SwitchToMap);
            });
           
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.fragment_main, container, false);
            _concertButton = view.FindViewById<Button>(Resource.Id.concertButton);
            return view;

            lectureButton = view.F
        }

       
    }
}