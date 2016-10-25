using Foundation;
using System;

using UIKit;

namespace TNPA.iOS
{
    public partial class HomePageController : UIViewController
    {
        public HomePageController(IntPtr handle) : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

           // this.btnTraCuu.TouchUpInside += btnTraCuu_Click;

            this.btnPhanAnh.TouchUpInside += (object sender, System.EventArgs ea) =>
            {
                TabController callHistory = this.Storyboard.InstantiateViewController("TabController") as TabController;
                if (callHistory != null)
                {
                    this.NavigationController.PushViewController(callHistory, true);
                }
            };
        }

        //async void btnTraCuu_Click(object sender, System.EventArgs ea)
        //{
        //    ViewController callHistory = this.Storyboard.InstantiateViewController("ViewController") as ViewController;
        //    if (callHistory != null)
        //    {
        //        this.NavigationController.PushViewController(callHistory, true);
        //    }
        //}

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);
            btnTraCuu.TouchUpInside += (object btnsender, System.EventArgs e) =>
            {
                // Launches a new instance of CallHistoryController
                ViewController callHistory = this.Storyboard.InstantiateViewController("ViewController") as ViewController;
                if (callHistory != null)
                {
                    this.NavigationController.PushViewController(callHistory, true);
                }
            };
        }
    }
}