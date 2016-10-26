using System;
using System.Linq;
using System.Collections.Generic;

using Foundation;
using UIKit;
using BarChart;

namespace Charts.Unified
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;

		public override UIWindow Window {
			get;
			set;
		}
		
		// This method is invoked when the application is about to move from active to inactive state.
		// OpenGL applications should use this method to pause.
		public override void OnResignActivation (UIApplication application)
		{
		}
		
		// This method should be used to release shared resources and it should store the application state.
		// If your application supports background exection this method is called instead of WillTerminate
		// when the user quits.
		public override void DidEnterBackground (UIApplication application)
		{
		}
		
		// This method is called as part of the transiton from background to active state.
		public override void WillEnterForeground (UIApplication application)
		{
		}
		
		// This method is called when the application is about to terminate. Save data, if needed.
		public override void WillTerminate (UIApplication application)
		{
		}

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);

			// If you have defined a root view controller, set it here:
			// window.RootViewController = myViewController;

			// make the window visible

			//			RootController rootController = new RootController ();
			//			window.RootViewController = rootController;

			//			pieChartViewController = new PieChartViewController ();
			//			window.RootViewController = pieChartViewController;

			//			lineChartViewController = new LineChartViewController ();
			//			window.RootViewController = lineChartViewController;

			ChartsTableViewController chartsTableViewController = new ChartsTableViewController ();

			UINavigationController navController = new UINavigationController (chartsTableViewController);

			window.RootViewController = navController;

			window.MakeKeyAndVisible ();

			return true;
		}
	}
}

