using System;
using System.Drawing;
using Foundation;
using UIKit;
using Alliance.Charts;

namespace BarChart
{
	public class ChartsTableViewController : UITableViewController
	{
		public ChartsTableViewController () : base (UITableViewStyle.Grouped)
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
			
			// Register the TableView's data source

			ChartsTableViewSource chartsTableViewSource = new ChartsTableViewSource ();
			chartsTableViewSource.chartsTableViewController = this;

			TableView.Source = chartsTableViewSource;

		}

		public void getRowSelectedIndex(int index)
		{
			if (index == 0) {

//				RootController rootController = new RootController ();
//				this.NavigationController.PushViewController (rootController,true);
				AllianceChartController allianceChartViewController = new AllianceChartController ();
				allianceChartViewController.ChartType = Chart.Bar;
				this.NavigationController.PushViewController (allianceChartViewController,true);


			} else if (index == 1) {

//				PieChartViewController pieChartViewController = new PieChartViewController ();
//				this.NavigationController.PushViewController (pieChartViewController,true);
				AllianceChartController allianceChartViewController = new AllianceChartController ();
				allianceChartViewController.ChartType = Chart.Pie;
				this.NavigationController.PushViewController (allianceChartViewController,true);

			} else {

//				LineChartViewController lineChartViewController = new LineChartViewController ();
//				this.NavigationController.PushViewController (lineChartViewController,true);
				AllianceChartController allianceChartViewController = new AllianceChartController ();
				allianceChartViewController.ChartType = Chart.Line;
				this.NavigationController.PushViewController (allianceChartViewController,true);

			}
		}
	}
}

