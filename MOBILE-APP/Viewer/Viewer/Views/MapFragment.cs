using Android.Runtime;
using Android.Locations;
using Android.Views;
using ReactiveUI;
using Viewer.ViewModels;
using Viewer.Models;
using Viewer.Views;
using Android.OS;

namespace Viewer.Views
{
    class MapFragment: ReactiveUI.ReactiveFragment<MapViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.fragment_map, container, false);

            return view;
            
        }
    }
}