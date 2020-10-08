using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Support.Design.Widget;
using System.Linq;
using Android.Content;
using Xamarin.Essentials;

namespace Laboratorinis2Tikras
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private string userInput {get;set;}
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Button button = FindViewById<Button>(Resource.Id.button1);
            button.Click += Button_Click;
            Button button2 = FindViewById<Button>(Resource.Id.button2);
            button2.Click += async delegate
            {
                EditText input = FindViewById<EditText>(Resource.Id.textInputEditText1);
                userInput = input.Text;
                await Share.RequestAsync(new ShareTextRequest
                {
                    Text = userInput
                });
            };
            Button button3 = FindViewById<Button>(Resource.Id.button3);
            button3.Click += delegate
            {
                Intent intent = new Intent(this, typeof(Activity2));
                StartActivityForResult(intent, 0);
            };
            Button button4 = FindViewById<Button>(Resource.Id.button4);
            button4.Click += Button4_Click; ;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Activity3));
            EditText input = FindViewById<EditText>(Resource.Id.textInputEditText1);
            intent.PutExtra("textToShow", input.Text);
            StartActivity(intent);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        private void Button_Click(object sender, EventArgs e)
        {
            EditText input = FindViewById<EditText>(Resource.Id.textInputEditText1);
            userInput = input.Text;
            TextView textView = FindViewById<TextView>(Resource.Id.textView2);
            if (userInput.Equals(""))
            {
                textView.Text = "0";
            }
            else
            {
                string[] userInputArray = userInput.Split(' ');
                textView.Text = userInputArray.Count().ToString();
            }
        }
        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if(resultCode == Result.Ok)
            {
                string result = data.GetStringExtra("user");
                EditText input = FindViewById<EditText>(Resource.Id.textInputEditText1);
                input.Text = result;
            }
        }
    }
}