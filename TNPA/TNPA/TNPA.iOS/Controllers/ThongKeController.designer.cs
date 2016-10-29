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
    [Register ("ThongKeController")]
    partial class ThongKeController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnBieuDo { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnDateEnd { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnDateStart { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lbTile { get; set; }

        [Action ("UIButton2303_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void UIButton2303_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnBieuDo != null) {
                btnBieuDo.Dispose ();
                btnBieuDo = null;
            }

            if (btnDateEnd != null) {
                btnDateEnd.Dispose ();
                btnDateEnd = null;
            }

            if (btnDateStart != null) {
                btnDateStart.Dispose ();
                btnDateStart = null;
            }

            if (lbTile != null) {
                lbTile.Dispose ();
                lbTile = null;
            }
        }
    }
}