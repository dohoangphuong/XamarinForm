using Alliance.Charts;
using System;
using System.Collections.Generic;
using UIKit;

namespace TNPA.iOS
{
	public partial class ViewController : UIViewController
	{

        //Create Instance for AllianceChart Classes
        public AllianceChart AllianceChart { get; set; }
        private Random random = new Random();

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //Pie Chart: Create object for AllianceChart by Passing ChartType and the View in which chart need to be populated.
            this.AllianceChart = new AllianceChart(Chart.Pie, this.View);
            createPieChart();

            this.View.SetNeedsDisplay();
        }


        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public void createPieChart()
        {
            List<ChartComponent> Components = new List<ChartComponent>();
                        
            Components.Add(createComponents("Africa", 1030));
            Components.Add(createComponents("Americas", 929));
            Components.Add(createComponents("Asia", 4157));
            Components.Add(createComponents("Europe", 739));
            Components.Add(createComponents("Oceania", 35));

            //Add more ChartComponent for more Slices in Pie Chart
            AllianceChart.PieChart.SameColorLabel = false;
            AllianceChart.PieChart.TitleFont = UIFont.FromName("HelveticaNeue-Bold", 15f);
            AllianceChart.PieChart.PercentageFont = UIFont.FromName("HelveticaNeue-Bold", 15f);

            AllianceChart.LoadChart(Components, Chart.Pie, this.View);
        }

        public ChartComponent createComponents(string name, float value)
        {
            ChartComponent ChartComponents = new ChartComponent();
            ChartComponents.Name = name;
            ChartComponents.axisLabelColor = UIColor.Black;
            ChartComponents.value = value;


            //auto color
            System.Threading.Thread.Sleep(10);
            float red = random.Next(0, 256);
            System.Threading.Thread.Sleep(10);
            nfloat screen = random.Next(0, 256);
            System.Threading.Thread.Sleep(10);
            nfloat blue = random.Next(0, 256);
            ChartComponents.color = UIColor.FromRGBA(red / 255, screen / 255, blue / 255, 1.0f);

            return ChartComponents;
        }

        /*Một số tùy chỉnh
        //To show value color same as PieChart slice color
        AllianceChart.PieChart.SameColorLabel = true; 

        //To customize Font of Name given to slice
        AllianceChart.PieChart.TitleFont = UIFont.FromName ("HelveticaNeue-Bold",15f);

        //To customize Font of Value given to slice 
        AllianceChart.PieChart.PercentageFont = UIFont.FromName ("HelveticaNeue-Bold",15f);

        //To show arrow to from the PieChart slice to value. By default it will be true
        AllianceChart.PieChart.ShowArrow = false;

        //To draw outline for the PieChart. By default it will be true
        AllianceChart.PieChart.Outline = false;

        //To set color to Arrow
        AllianceChart.PieChart.ArrowColor = UIColor.Black;

        //To show value or calculate and show percentange value of slice
        AllianceChart.PieChart.ShowPercentage = false; 
         */
    }
}
