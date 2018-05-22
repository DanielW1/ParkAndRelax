using Viewer.ViewModels;
using ReactiveUI;
using Android.OS;
using Android.Views;
using System;
using Android.Widget;
using Com.Wdullaer.Materialdatetimepicker.Time;
using Android.Icu.Util;
using Com.Wdullaer.Materialdatetimepicker.Date;
using Android.App;


namespace Viewer.Droid.Views
{
    public class DateFragment:ReactiveUI.AndroidSupport.ReactiveFragment<DateViewModel>, Com.Wdullaer.Materialdatetimepicker.Date.DatePickerDialog.IOnDateSetListener, Com.Wdullaer.Materialdatetimepicker.Time.TimePickerDialog.IOnTimeSetListener
    {
        Button _dateButton;
        Button _timeButton;
        Button _chooseButton;
        public DateFragment()
        {
            this.WhenActivated(disposable =>
            {

            });
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.fragment_date, container, false);

            
            _dateButton = view.FindViewById<Button>(Resource.Id.dateButton);
            _timeButton = view.FindViewById<Button>(Resource.Id.timeButton);
            _chooseButton = view.FindViewById<Button>(Resource.Id.chooseButton);

            _dateButton.Click += delegate
            {
                Calendar now = Calendar.Instance;
                Com.Wdullaer.Materialdatetimepicker.Date.DatePickerDialog datePicker = Com.Wdullaer.Materialdatetimepicker.Date.DatePickerDialog
                .NewInstance(
                    this,
                    now.Get(CalendarField.Year),
                    now.Get(CalendarField.Month),
                    now.Get(CalendarField.DayOfMonth));
                datePicker.SetTitle("Wybierz datę");
                //datePicker.Show(FragmentManager, "DatePicker");

            };

            _timeButton.Click += delegate
            {
                Calendar now = Calendar.Instance;
                Com.Wdullaer.Materialdatetimepicker.Time.TimePickerDialog timePicker = Com.Wdullaer.Materialdatetimepicker.Time.TimePickerDialog.NewInstance(
                    this,
                    now.Get(CalendarField.HourOfDay),
                    now.Get(CalendarField.Minute),
                    true); 
                timePicker.Title = "Wybierz czas";
                //timePicker.Show(FragmentManager, "DatePicker");
            };

            return view;
        }

        public void OnDateSet(Com.Wdullaer.Materialdatetimepicker.Date.DatePickerDialog p0, int year, int monthOfYear, int dayOfMonth)
        {
            Toast.MakeText(Application.Context, $"Wybrałeś: {monthOfYear}/{dayOfMonth}/{year + 1}", ToastLength.Long).Show();
            //string date = "{ monthOfYear }/{ dayOfMonth}/{ year + 1}";
        }

        public void OnTimeSet(RadialPickerLayout p0, int hourOfDay, int minute, int second)
        {
            Toast.MakeText(Application.Context, $"Wybrałeś: {string.Format("{0:00}", hourOfDay)}:{string.Format("{0:00}", minute)}:{string.Format("{0:00}", second)}", ToastLength.Long).Show();
        }
    }

    }
