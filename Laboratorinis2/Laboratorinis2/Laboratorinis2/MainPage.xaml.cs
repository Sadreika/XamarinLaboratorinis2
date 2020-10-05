using Android.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Laboratorinis2
{
    public partial class MainPage : ContentPage
    {
        private bool timerRunning { get; set; }
        private Random random = new Random();
        public MainPage()
        {
            InitializeComponent();
        }
        private void FirstButton_Clicked(object sender, EventArgs e)
        {
            generatingNumber(-100, 0);
        }
        private void SecondButton_Clicked(object sender, EventArgs e)
        {
            stopping();
        }
        private void ThirdButton_Clicked(object sender, EventArgs e)
        {
            generatingNumber(0, 101);
        }
        private void FourthButton_Clicked(object sender, EventArgs e)
        {
            stopping();
        }
        private void stopping()
        {
            timerRunning = false;
            string mySearchQuery = NumberEntry.Text;
            try
            {
                Int16.Parse(mySearchQuery);
                Device.OpenUri(new Uri($"https://www.google.com/search?q={mySearchQuery}"));
            }
            catch (Exception)
            {
            }
        }
        private void generatingNumber(int from, int to)
        {
            if(timerRunning.Equals(true))
            {
                timerRunning = false;
            }
            else
            {
                timerRunning = true;
                Device.StartTimer(TimeSpan.FromSeconds(0.5), () =>
                {
                    if (timerRunning.Equals(true))
                    {
                        int rand_num = random.Next(from, to);
                        NumberEntry.Text = rand_num.ToString();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                });
            }
        }
    }
}
