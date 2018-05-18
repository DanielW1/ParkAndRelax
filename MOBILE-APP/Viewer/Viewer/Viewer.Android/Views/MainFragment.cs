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
        Button _mapButton;
        public MainFragment()
        {
           /* ViewModel.NavigateToMap.Subscribe(MapViewModel =>
            {
                var mapFragment = new MapFragment { ViewModel = MapViewModel };
                Activity.NextFragment(Resource.Id.frame, mapFragment);
            });*/
            //_mapButton.Events().Click.Select(_ => Unit.Default).InvokeCommand(this, x => x.ViewModel.NavigateToMap);
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.fragment_main, container, false);
            _mapButton = view.FindViewById<Button>(Resource.Id.mapButton);
            return view;
        }
    }
}