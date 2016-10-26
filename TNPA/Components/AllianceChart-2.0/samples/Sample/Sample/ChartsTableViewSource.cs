using System;
using System.Drawing;
using Foundation;
using UIKit;

namespace BarChart
{
	public class ChartsTableViewSource : UITableViewSource
	{
		public ChartsTableViewController chartsTableViewController;

		public ChartsTableViewSource ()
		{
		}

		public override nint NumberOfSections (UITableView tableView)
		{
			// TODO: return the actual number of sections
			return 1;
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			// TODO: return the actual number of items in the section
			return 3;
		}

//		public override string TitleForHeader (UITableView tableView, int section)
//		{
//			return "Header";
//		}
//
//		public override string TitleForFooter (UITableView tableView, int section)
//		{
//			return "Footer";
//		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (ChartsTableViewCell.Key) as ChartsTableViewCell;
			if (cell == null)
				cell = new ChartsTableViewCell ();
			
			// TODO: populate the cell with the appropriate data based on the indexPath
//			cell.DetailTextLabel.Text = "DetailsTextLabel";

			if (indexPath.Row == 0) {
				cell.TextLabel.Text = "Bar Chart";
			} else if (indexPath.Row == 1) {
				cell.TextLabel.Text = "Pie Chart";
			} else {
				cell.TextLabel.Text = "Line Chart";
			}
			
			return cell;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			chartsTableViewController.getRowSelectedIndex (indexPath.Row);
		}
	}
}

