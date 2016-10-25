// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace TNPA.iOS
{
    [Register ("HomePageController")]
    partial class HomePageController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnPhanAnh { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnTraCuu { get; set; }

        [Action ("BtnTraCuu_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnTraCuu_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnPhanAnh != null) {
                btnPhanAnh.Dispose ();
                btnPhanAnh = null;
            }

            if (btnTraCuu != null) {
                btnTraCuu.Dispose ();
                btnTraCuu = null;
            }
        }
    }
}