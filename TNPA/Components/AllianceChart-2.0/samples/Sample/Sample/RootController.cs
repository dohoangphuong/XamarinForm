using System;
using System.Drawing;
using Foundation;
using UIKit;
using CoreGraphics;
using System.Collections.Generic;
using CoreText;
using Alliance.Charts;


namespace BarChart
{
    public class RootController : UIViewController
    {
        public BarChartView BarChart { get; set; }

		public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.LoadBarChartUsingArray();
        }
			
        void LoadBarChartUsingArray()
        {

			CGRect frame = this.View.Frame;
			this.View.BackgroundColor = UIColor.White;

			BarChart = new BarChartView (new CGRect(10,30,frame.Size.Width-20,frame.Size.Height-30));
			BarChart.barWidth = 40;

			List<BarPoint> barPointList = new List<BarPoint> ();

			BarPoint barPoint1 = new BarPoint ();
			barPoint1.label = "Title 1";
			barPoint1.value = 46.7f;
			barPoint1.color = UIColor.FromRGB (135f/255f,227f/255f,23f/255f);
			barPoint1.colorLabel = UIColor.Black;
			barPointList.Add (barPoint1);

			BarPoint barPoint2 = new BarPoint ();
			barPoint2.label = "Title 2";
			barPoint2.value = 18.3f;
			barPoint2.color = UIColor.FromRGB (23f/255f,169f/255f,227f/255f);
			barPoint2.colorLabel = UIColor.Black;
			barPointList.Add (barPoint2);

			BarPoint barPoint3 = new BarPoint ();
			barPoint3.label = "Title 3";
			barPoint3.value = 40f;
			barPoint3.color = UIColor.FromRGB (227f/255f,47f/255f,23f/255f);
			barPoint3.colorLabel = UIColor.Black;
			barPointList.Add (barPoint3);

			BarPoint barPoint4 = new BarPoint ();
			barPoint4.label = "Title 4";
			barPoint4.value = 10.4f;
			barPoint4.color = UIColor.FromRGB (255f/255f,229f/255f,61f/255f);
			barPoint4.colorLabel = UIColor.Black;
			barPointList.Add (barPoint4);

			BarPoint barPoint5 = new BarPoint ();
			barPoint5.label = "Title 5";
			barPoint5.value = 36.7f;
			barPoint5.color = UIColor.FromRGB (135f/255f,227f/255f,23f/255f);
			barPoint5.colorLabel = UIColor.Black;
			barPointList.Add (barPoint5);

			BarPoint barPoint6 = new BarPoint ();
			barPoint6.label = "Title 6";
			barPoint6.value = 28.3f;
			barPoint6.color = UIColor.FromRGB (23f/255f,169f/255f,227f/255f);
			barPoint6.colorLabel = UIColor.Black;
			barPointList.Add (barPoint6);

			this.BarChart.SetupBarViewShape(BarShape.Rounded);
			this.BarChart.SetupBarViewStyle(BarDisplayStyle.BarStyleMatte);
			this.BarChart.SetupBarViewShadow(BarShadow.Light);
			this.BarChart.SetDataWithArrayShowAxisWithColorShouldPlotVerticalLines(barPointList, AxisDisplaySetting.DisplayBothAxes, UIColor.White, true);

			this.View.AddSubview (BarChart);
        }

        void LoadBarChartUsingXML()
        {
			this.BarChart.SetupBarViewShape(BarShape.Squared);
			this.BarChart.SetupBarViewStyle(BarDisplayStyle.BarStyleFlat);
			this.BarChart.SetupBarViewShadow(BarShadow.Light);
//            this.BarChart.SetXmlDataShowAxisWithColorShouldPlotVerticalLines(NSData.DataWithContentsOfFile(NSBundle.MainBundle().PathForResourceOfType("barChart", "xml")), DisplayBothAxes, UIColor.WhiteColor(), true);
        }

        public void DismissController(object sender)
        {
//            this.DismissViewControllerAnimatedCompletion(true, null);
			this.DismissViewController (true,null);
        }

        public void ViewDocumentation(object sender)
        {
//            string url = NSString.StringWithFormat("https://github.com/iRareMedia/BarChart/blob/master/README.md");
//            UIApplication.SharedApplication().OpenURL(NSURL.URLWithString(url));
        }

    }
}
