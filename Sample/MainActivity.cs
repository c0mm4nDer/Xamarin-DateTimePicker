using Android.App;
using Android.Widget;
using Android.OS;

using Com.Android.Datetimepicker.Time;
using System;
using Com.Android.Datetimepicker.Date;

namespace Sample
{
    [Activity(Label = "Sample", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, Com.Android.Datetimepicker.Date.DatePickerDialog.IOnDateSetListener, Com.Android.Datetimepicker.Time.TimePickerDialog.IOnTimeSetListener
    {
        TextView mTextView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            var btn = FindViewById<Button>(Resource.Id.button1);
            var btn2 = FindViewById<Button>(Resource.Id.button2);
            mTextView = FindViewById<TextView>(Resource.Id.textView1);

            btn.Click += delegate {

                Com.Android.Datetimepicker.Time.TimePickerDialog.NewInstance(this, DateTime.Now.Hour , DateTime.Now.Minute, true).Show(FragmentManager, "timePicker");
            };

            btn2.Click += delegate {

                Com.Android.Datetimepicker.Date.DatePickerDialog.NewInstance(this, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).Show(FragmentManager, "timePicker");
            };
        }

        public void OnDateSet(Com.Android.Datetimepicker.Date.DatePickerDialog view, int p1, int p2, int p3)
        {
            mTextView.Text = p1.ToString() + "/" + p2.ToString()+ "/" + p3.ToString();
        }

        public void OnTimeSet(RadialPickerLayout view, int hour, int minute)
        {
            mTextView.Text = hour.ToString() + ":" + minute.ToString();
        }
    }
}

