using Foundation;
using System;

using UIKit;

namespace TNPA.iOS
{
    public partial class MainPageController : UIViewController
    {
        public int _SelectItem { get; set; }
        public MainPageController(IntPtr handle) : base(handle)
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

            this.btnTraCuu.TouchDown += (object btnsender, System.EventArgs ea) =>
            {
                _SelectItem = 0;
            };
            
            this.btnPhanAnh.TouchDown += (object btnsender, System.EventArgs ea) =>
            {
                _SelectItem = 1;
            };

            this.btnThongKe.TouchDown += (object btnsender, System.EventArgs ea) =>
            {
                _SelectItem = 2;
            };

            this.btnCaiDat.TouchDown += (object btnsender, System.EventArgs ea) =>
            {
                _SelectItem = 3;
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


        /// <summary>
        /// Hàm này tự động được gọi trước khi chuyển sang màn hình khác: Gọi trước cả hàm TouchUpInside nhưng sau hàm TouchDown.
        /// Mục đích: Dùng để cập nhật giá trị trước khi chuyển, đã gán root và đường dẫn trên giao diện nên không cần thiết khởi tạo rồi gọi đến 1 controller khác
        /// </summary>
        /// <param name="segue"></param>
        /// <param name="sender"></param>
        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);
            var tabController = segue.DestinationViewController as TabController;

            //set item in the tab controller
            if (tabController != null)
            {
                tabController.SelectedIndex = _SelectItem;
            }
        }
    }
}