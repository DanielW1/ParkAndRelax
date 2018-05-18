using Android.App;
using Android.Support.V7.App;

namespace Viewer.Droid.Helpers
{
    public static class NavigateToFragment
    {


        public static void NextFragment(this Activity This, int containerViewId, ReactiveUI.AndroidSupport.ReactiveFragment fragment, string tag = null)
        {
            var activity = (AppCompatActivity)This;

            var transaction = activity.SupportFragmentManager.BeginTransaction();
            if (tag == null)
                tag = fragment.GetHashCode().ToString();

            transaction.Replace(containerViewId, fragment, tag);
            transaction.AddToBackStack(tag);
            transaction.Commit();
        }
    }
}