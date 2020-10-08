using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Essentials;

namespace Laboratorinis2Tikras
{
    [Activity(Label = "Activity3")]
    public class Activity3 : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layout3);
            string text = Intent.GetStringExtra("textToShow");
            TextView textView = FindViewById<TextView>(Resource.Id.textView1);
            textView.Text = text;
            Button button1 = FindViewById<Button>(Resource.Id.button1);
            button1.Click += async delegate
            {
                Share.RequestAsync(new ShareTextRequest
                {
                    Text = textView.Text
                });
            };
        }
    }
}