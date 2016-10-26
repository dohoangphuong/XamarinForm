using System;
using System.Drawing;
using Foundation;
using UIKit;
using System.Collections.Generic;
using Alliance.Charts;
using CoreGraphics;

namespace BarChart
{
	public partial class AllianceChartController : UIViewController
	{

		public Chart ChartType{ get; set;}
		public AllianceChart AllianceChart { get; set;}

		public AllianceChartController () : base ("AllianceChartController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			if (UIDevice.CurrentDevice.CheckSystemVersion(7, 0))
				this.EdgesForExtendedLayout = UIRectEdge.None;

			this.View.Frame = new CGRect (this.View.Frame.X, this.View.Frame.Y, this.View.Frame.Width, this.View.Frame.Height);

			this.AllianceChart = new AllianceChart (ChartType,this.View, new CGSize(800f,this.View.Frame.Height));
//			this.AllianceChart = new AllianceChart (ChartType,this.View);


			if (ChartType == Chart.Bar) {
			
				createBarChart ();

			} else if (ChartType == Chart.Line) {
			
				createLineChart ();

			} else if (ChartType == Chart.Pie) {
			
				createPieChart ();
			}

			this.View.SetNeedsDisplay ();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void WillRotate (UIInterfaceOrientation toInterfaceOrientation, double duration)
		{
			base.WillRotate (toInterfaceOrientation, duration);

			if (ChartType == Chart.Line) {
				if (AllianceChart.LineChartView != null)
					AllianceChart.LineChartView.RemoveFromSuperview ();
				AllianceChart = new AllianceChart (ChartType, this.View);
				createLineChart ();
			} 
		}

		public void createLineChart()
		{
		
			List<string> X_labels = new List<string>{"Jan","Feb","Mar","Apr","May","Jun"};
			AllianceChart.LineChartView.XLabels = X_labels;
			AllianceChart.LineChartView.PopOverTextColor = UIColor.White;
			AllianceChart.LineChartView.BackgroundColor = UIColor.White;

			List<ChartComponent> components = new List<ChartComponent>();

			ChartComponent chartComponent1 = new ChartComponent ();
			chartComponent1.Name = "Smith";
			chartComponent1.valueList = new List<float?>{20f,10f,35f,45f,69f,70f};
			chartComponent1.color = UIColor.FromRGB (23f/255f,169f/255f,227f/255f);
			chartComponent1.lableColor = UIColor.Black;
			components.Add (chartComponent1);

			AllianceChart.LoadChart (components, Chart.Line, this.View);

		}

		public void createBarChart()
		{
		
			AllianceChart.BarChart.SetupBarViewShape(BarShape.Rounded);
			AllianceChart.BarChart.SetupBarViewStyle(BarDisplayStyle.BarStyleMatte);
			AllianceChart.BarChart.SetupBarViewShadow(BarShadow.Light);
			AllianceChart.BarChart.barWidth = 40;

			List<ChartComponent> components = new List<ChartComponent>();

			ChartComponent chartComponent1 = new ChartComponent ();
			chartComponent1.Name = "Title 1";
			chartComponent1.value = 45.0f;
			chartComponent1.color = UIColor.FromRGB (135f/255f,227f/255f,23f/255f);
			chartComponent1.lableColor = UIColor.Black;
			components.Add (chartComponent1);

			ChartComponent chartComponent2 = new ChartComponent ();
			chartComponent2.Name = "Title 2";
			chartComponent2.value = 18.3f;
			chartComponent2.color = UIColor.FromRGB (23f/255f,169f/255f,227f/255f);
			chartComponent2.lableColor = UIColor.Black;
			components.Add (chartComponent2);

			ChartComponent chartComponent3 = new ChartComponent ();
			chartComponent3.Name = "Title 3";
			chartComponent3.value = 40f;
			chartComponent3.color = UIColor.FromRGB (227f/255f,47f/255f,23f/255f);
			chartComponent3.lableColor = UIColor.Black;
			components.Add (chartComponent3);

			ChartComponent chartComponent4 = new ChartComponent ();
			chartComponent4.Name = "Title 4";
			chartComponent4.value = 10.4f;
			chartComponent4.color =  UIColor.FromRGB (255f/255f,229f/255f,61f/255f);
			chartComponent4.lableColor = UIColor.Black;
			components.Add (chartComponent4);

			ChartComponent chartComponent5 = new ChartComponent ();
			chartComponent5.Name = "Title 5";
			chartComponent5.value = 36.7f;
			chartComponent5.color =  UIColor.FromRGBA (1.0f, 153f / 255.0f, 51f / 255.0f, 1.0f);
			chartComponent5.lableColor = UIColor.Black;
			components.Add (chartComponent5);

			ChartComponent chartComponent6 = new ChartComponent ();
			chartComponent6.Name = "Title 6";
			chartComponent6.value = 10.4f;
			chartComponent6.color =  UIColor.FromRGB (135f/255f,227f/255f,23f/255f);
			chartComponent6.lableColor = UIColor.Black;
			components.Add (chartComponent6);

			ChartComponent chartComponent7 = new ChartComponent ();
			chartComponent7.Name = "Title 7";
			chartComponent7.value = 36.7f;
			chartComponent7.color =  UIColor.FromRGB (23f/255f,169f/255f,227f/255f);
			chartComponent7.lableColor = UIColor.Black;
			components.Add (chartComponent7);

			ChartComponent chartComponent8 = new ChartComponent ();
			chartComponent8.Name = "Title 8";
			chartComponent8.value = 10.4f;
			chartComponent8.color =  UIColor.FromRGB (227f/255f,47f/255f,23f/255f);
			chartComponent8.lableColor = UIColor.Black;
			components.Add (chartComponent8);

			ChartComponent chartComponent9 = new ChartComponent ();
			chartComponent9.Name = "Title 9";
			chartComponent9.value = 36.7f;
			chartComponent9.color =  UIColor.FromRGB (255f/255f,229f/255f,61f/255f);
			chartComponent9.lableColor = UIColor.Black;
			components.Add (chartComponent9);

			AllianceChart.LoadChart (components, Chart.Bar, this.View);

		}

		public void createPieChart()
		{

			AllianceChart.PieChart.SameColorLabel = false;
			AllianceChart.PieChart.TitleFont = UIFont.FromName ("HelveticaNeue-Regular",12f);
			AllianceChart.PieChart.PercentageFont = UIFont.FromName ("HelveticaNeue-Regular",12f);
			AllianceChart.PieChart.Diameter = 140;

			List<ChartComponent> components = new List<ChartComponent>();

			ChartComponent chartComponent1 = new ChartComponent ();
			chartComponent1.Name = "AAA";
			chartComponent1.value = 20.0f;
			chartComponent1.color = UIColor.FromRGBA (1.0f, 220f / 255.0f, 0.0f, 1.0f);
			components.Add (chartComponent1);

			ChartComponent chartComponent2 = new ChartComponent ();
			chartComponent2.Name = "BBB";
			chartComponent2.value = 10.0f;
			chartComponent2.color = UIColor.FromRGBA (0.0f, 153f / 255.0f, 204f / 255.0f, 1.0f);
			components.Add (chartComponent2);

			ChartComponent chartComponent3 = new ChartComponent ();
			chartComponent3.Name = "CCC";
			chartComponent3.value = 20.0f;
			chartComponent3.color = UIColor.FromRGBA (153f / 255.0f, 204f / 255.0f, 51f / 255.0f, 1.0f);
			components.Add (chartComponent3);

			ChartComponent chartComponent4 = new ChartComponent ();
			chartComponent4.Name = "DDD";
			chartComponent4.value = 30.0f;
			chartComponent4.color = UIColor.FromRGBA (1.0f, 153f / 255.0f, 51f / 255.0f, 1.0f);
			components.Add (chartComponent4);

			ChartComponent chartComponent5 = new ChartComponent ();
			chartComponent5.Name = "EEE";
			chartComponent5.value = 60.0f;
			chartComponent5.color = UIColor.FromRGBA (1.0f, 51f / 255.0f, 51f / 255.0f, 1.0f);
			components.Add (chartComponent5);

			AllianceChart.LoadChart (components, Chart.Pie, this.View);

		}
	}
}

