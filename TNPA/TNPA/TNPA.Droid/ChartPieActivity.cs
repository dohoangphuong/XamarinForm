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
using OxyPlot.Xamarin.Android;
using OxyPlot;
using OxyPlot.Series;

namespace TNPA.Droid
{
    [Activity(MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/Theme.NoActionBar")]
    public class ChartPieActivity : Activity
    {
        PlotView view;
        Button btn3;
        Button btnPieSeries;
        List<ModelChartPie> lstChartPie;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.PageChartPie);

            //OxyPlot
            view = FindViewById<PlotView>(Resource.Id.plot_view);
            btn3= FindViewById<Button>(Resource.Id.btnGrafico3);            
            btnPieSeries = FindViewById<Button>(Resource.Id.btnPieSeries);

            //even click
            btn3.Click += Btn3_Click;
            btnPieSeries.Click += btnPieSeries_Click;

            lstChartPie = new List<ModelChartPie>();
            lstChartPie.Add(new ModelChartPie("Africa", 1030));
            lstChartPie.Add(new ModelChartPie("Asian", 2157));
            lstChartPie.Add(new ModelChartPie("Europa", 600));
            lstChartPie.Add(new ModelChartPie("Oceania", 780));
            lstChartPie.Add(new ModelChartPie("Americas", 929));
            lstChartPie.Add(new ModelChartPie("Australia", 1300));
            lstChartPie.Add(new ModelChartPie("Antarctica", 10));
        }
       
        private void Btn3_Click(object sender, EventArgs e)
        {
            view.Model = Grafico3();
        }
        private void btnPieSeries_Click(object sender, EventArgs e)
        {
            view.Model = GetChartPie(lstChartPie);
        }

        //Chart pie
        private PlotModel GetChartPie(List<ModelChartPie> fLstCharPie)
        {
            PlotModel modellP1 = new PlotModel
            {
                Title = "BIỂU ĐỒ",
                Padding = new OxyThickness(40, 25, 40, 25),
                TitleFontSize = 30,
            };

            //DefaultFontSize            
            if (fLstCharPie.Count() > 0)
            {
                var seriesP1 = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.8, AngleSpan = 360, StartAngle = 0 };

                seriesP1.Slices.Add(new PieSlice(fLstCharPie[0]._Name, fLstCharPie[0]._Value) { IsExploded = false, Fill = OxyColors.PaleVioletRed });

                if (fLstCharPie.Count() > 1)
                {
                    for (int i = 1; i < fLstCharPie.Count(); i++)
                    {
                        seriesP1.Slices.Add(new PieSlice(fLstCharPie[i]._Name, fLstCharPie[i]._Value) { IsExploded = true });
                    }
                    modellP1.Series.Add(seriesP1);
                }
            }
            else
            {
                modellP1.Title = "CHƯA CÓ DỮ LIỆU";
            }

            return modellP1;
        }

        //Chart pie
        private PlotModel Grafico3()
        {
            PlotModel modellP1 = new PlotModel { Title = "Biểu đồ",
                Padding = new OxyThickness(40, 25, 40, 25),
                TitleFontSize = 30,
            };
            //DefaultFontSize
            var seriesP1 = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.8, AngleSpan = 360, StartAngle = 0 };

            seriesP1.Slices.Add(new PieSlice("Africa", 1030) { IsExploded = false, Fill = OxyColors.PaleVioletRed });
            seriesP1.Slices.Add(new PieSlice("Americas", 929) { IsExploded = true });
            seriesP1.Slices.Add(new PieSlice("Asian", 2157) { IsExploded = true });
            seriesP1.Slices.Add(new PieSlice("Europa", 739) { IsExploded = true });
            seriesP1.Slices.Add(new PieSlice("Oceania", 780) { IsExploded = true });
           
            modellP1.Series.Add(seriesP1);

            return modellP1;
        }       
    }

    public class ModelChartPie
    {
        public string _Name;
        public double _Value;
        public ModelChartPie() { }
        public ModelChartPie(string fName,double fValue)
        {
            _Name = fName;
            _Value = fValue;
        }
    }
}