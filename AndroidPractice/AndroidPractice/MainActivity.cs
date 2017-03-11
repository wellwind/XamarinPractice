using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace AndroidPractice
{
    [Activity(Label = "AndroidPractice", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            Button btnShow = FindViewById<Button>(Resource.Id.btnShow);

            var editText = FindViewById<EditText>(Resource.Id.editText1);
            var textView = FindViewById<TextView>(Resource.Id.textView1);

            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };

            btnShow.Click += (sender, args) =>
            {
                textView.Text = editText.Text;
            };
        }
        
    }
}



