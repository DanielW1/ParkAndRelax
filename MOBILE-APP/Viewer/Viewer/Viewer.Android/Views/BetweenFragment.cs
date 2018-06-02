using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Viewer.ViewModels;
using Viewer.Droid.Helpers;
using System.Reactive;
using System.Reactive.Disposables;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ReactiveUI;
using System.Reactive.Linq;
using System.Threading;

namespace Viewer.Droid.Views
{
    public class BetweenFragment: ReactiveUI.AndroidSupport.ReactiveFragment<BetweenViewModel>

    {
        Button _nextButton;
        public BetweenFragment()

        {

            this.WhenActivated(disposable =>
            {
                ViewModel.SwitchToEventsListFromBetween.Subscribe(betweenViewModel =>
            {
                //Thread.Sleep(3000);
                var betweenFragment = new EventsListFragment(ViewModel.EventsList) { ViewModel = betweenViewModel };
                Activity.NextFragment(Resource.Id.frame, betweenFragment);
            }
              ).DisposeWith(disposable);

                _nextButton.Events().Click.Select(_ => Unit.Default).InvokeCommand(this, x => x.ViewModel.SwitchToEventsListFromBetween).DisposeWith(disposable);
            });

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            Thread.Sleep(5000);
            var view = inflater.Inflate(Resource.Layout.between, container, false);
            _nextButton = view.FindViewById<Button>(Resource.Id.nextButton);


            return view;

        }
    }
}