using Android.App;
using Android.Widget;
using Android.OS;

namespace Viewer
{
    [Activity(Label = "Viewer", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Bootstraper.Initialize();
            BootstraperDroid.Initialize();
            SetContentView(Resource.Layout.fragment_map);
        }
    }
}

