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
using BarChart;

namespace TNPA.Droid
{
    [Activity(Label = "ChartActivity", MainLauncher = true)]
    public class ChartActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var data = new[] { 1f, 2f, 4f, 8f, 16f, 32f , 0.5f, 10f, 0f, 40f};
            var chart = new BarChartView(this)
            {
                ItemsSource = Array.ConvertAll(data, v => new BarModel { Value = v })
            };

            AddContentView(chart, new ViewGroup.LayoutParams(
              ViewGroup.LayoutParams.FillParent, ViewGroup.LayoutParams.FillParent));

            chart.BarClick += (sender, args) => {
                BarModel bar = args.Bar;
                DisplayAlert("Alert", "You have been alerted", "OK");
                Console.WriteLine("Pressed {0}", bar);
            };
        }
    }
}