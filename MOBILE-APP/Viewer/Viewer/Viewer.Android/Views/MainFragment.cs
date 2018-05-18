using Viewer.ViewModels;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using ReactiveUI;
using System;
using System.Collections.Generic;
using Viewer.Models;
using Splat;
using Viewer.Services;

namespace Viewer.Droid.Views
{
    public class MainFragment:ReactiveUI.AndroidSupport.ReactiveFragment<MainViewModel>
    {
        public MainFragment()
        {
            this.WhenActivated( disposable =>
            {

            });
        }
    }
}