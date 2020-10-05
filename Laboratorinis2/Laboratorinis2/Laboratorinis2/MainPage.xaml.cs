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
        private bool firstTimerRunning { get; set; }
        private bool secondTimerRunning { get; set; }
        private Random random = new Random();
        public MainPage()
        {
            InitializeComponent();
        }

        private void FirstButton_Clicked(object sender, EventArgs e)
        {
            firstTimerRunning = true;
            Device.StartTimer(TimeSpan.FromSeconds(0.5), () =>
            {
                int rand_num = random.Next(-100, 1);
                NumberEntry.Text = rand_num.ToString();
                if (firstTimerRunning.Equals(true))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            });
        }

        private void SecondButton_Clicked(object sender, EventArgs e)
        {
            firstTimerRunning = false;
            string mySearchQuery = NumberEntry.Text;
            try
            {
                Int16.Parse(mySearchQuery);
                Device.OpenUri(new Uri($"https://www.google.com/search?q={mySearchQuery}"));
            }
            catch(Exception)
            {

            }
        }

        private void ThirdButton_Clicked(object sender, EventArgs e)
        {
            secondTimerRunning = true;
            Device.StartTimer(TimeSpan.FromSeconds(0.5), () =>
            {
                int rand_num = random.Next(0, 101);
                SecondNumberEntry.Text = rand_num.ToString();
                if (secondTimerRunning.Equals(true))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            });
        }

        private void FourthButton_Clicked(object sender, EventArgs e)
        {
            secondTimerRunning = false;
            string mySearchQuery = SecondNumberEntry.Text;
            try
            {
                Int16.Parse(mySearchQuery);
                Device.OpenUri(new Uri($"https://www.google.com/search?q={mySearchQuery}"));
            }
            catch (Exception)
            {

            }
        }
    }
}
