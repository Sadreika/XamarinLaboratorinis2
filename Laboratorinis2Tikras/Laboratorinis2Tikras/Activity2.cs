using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;

namespace Laboratorinis2Tikras
{
    [Activity(Label = "Activity2")]
    public class Activity2 : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layout2);
            Button button = FindViewById<Button>(Resource.Id.button1);
            button.Click += Button_Click;
        }
        private void Button_Click(object sender, EventArgs e)
        {
            
            TextInputEditText input = FindViewById<TextInputEditText>(Resource.Id.textInputEditText1);
            Intent intent = new Intent(this, typeof(MainActivity));
            Intent.PutExtra("userInput", input.ToString());
            StartActivity(intent);
            SetContentView(Resource.Layout.activity_main);
        }
    }
}