using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Viewer.Droid.Views;
using Viewer.ViewModels;
using Viewer.Droid.Helpers;
using ReactiveUI.AndroidSupport;
using Android.Widget;
using System.Reactive.Linq;
using System.Reactive;
using ReactiveUI;
using ReactiveUI.Legacy;
using Android.Content;
using Android.Icu.Util;
using Com.Wdullaer.Materialdatetimepicker.Date;
using Com.Wdullaer.Materialdatetimepicker.Time;

namespace Viewer.Droid
{
    [Activity(Label = "Viewer",
        MainLauncher = true,
        Theme = "@style/MainTheme",
        Icon = "@drawable/icon",

        ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]
    public class MainActivity : Activity,Com.Wdullaer.Materialdatetimepicker.Date.DatePickerDialog.IOnDateSetListener,Com.Wdullaer.Materialdatetimepicker.Time.TimePickerDialog.IOnTimeSetListener

    {

        //ReactiveAppCompatActivity
        Button btnDatePicker, btnTimePicker;

        public void OnDateSet(Com.Wdullaer.Materialdatetimepicker.Date.DatePickerDialog p0, int year, int monthOfYear, int dayOfMonth)
        {
            Toast.MakeText(this, $"Wybrałeś: {monthOfYear}/{dayOfMonth}/{year + 1}", ToastLength.Long).Show();
            string date = "{ monthOfYear }/{ dayOfMonth}/{ year + 1}";
        }

        public void OnTimeSet(RadialPickerLayout p0, int hourOfDay, int minute, int second)
        {
            Toast.MakeText(this, $"Wybrałeś: {string.Format("{0:00}",hourOfDay)}:{string.Format("{0:00}", minute)}:{string.Format("{0:00}",second)}",ToastLength.Long).Show();
        }

        protected override void OnCreate(Bundle bundle)
        {
            BootstraperDroid.Initialize();
            Bootstrapper.Initialize();

            base.OnCreate(bundle);

            SetContentView(Resource.Layout.First);

            btnDatePicker = FindViewById<Button>(Resource.Id.btnDatePicker);
            btnTimePicker = FindViewById<Button>(Resource.Id.btnTimePicker);

            btnDatePicker.Click += delegate
             {
                 Calendar now = Calendar.Instance;
                 Com.Wdullaer.Materialdatetimepicker.Date.DatePickerDialog datePicker = Com.Wdullaer.Materialdatetimepicker.Date.DatePickerDialog.NewInstance(
                     this,
                     now.Get(CalendarField.Year),
                     now.Get(CalendarField.Month),
                     now.Get(CalendarField.DayOfMonth));
                 datePicker.SetTitle("DatePicker Dialog");
                 datePicker.Show(FragmentManager, "DatePicker");

             };

            btnTimePicker.Click += delegate
            {
                Calendar now = Calendar.Instance;
                Com.Wdullaer.Materialdatetimepicker.Time.TimePickerDialog timePicker = Com.Wdullaer.Materialdatetimepicker.Time.TimePickerDialog.NewInstance(
                    this,
                    now.Get(CalendarField.HourOfDay),
                    now.Get(CalendarField.Minute),
                    true); //true - dostępne 24h
                timePicker.Title ="TimePicker Dialog";
                timePicker.Show(FragmentManager, "DatePicker");
            };
            /*var mainFragment = new MainFragment(){ ViewModel = new MainViewModel()};
            this.NextFragment(Resource.Id.frame, mainFragment);
            */
            var dateButton = FindViewById<Button>(Resource.Id.dateButton);
            dateButton.Click += (s, e) =>
            {
               
            };

            
        }
    }
}
