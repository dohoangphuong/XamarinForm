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
    [Register ("MainPageController")]
    partial class MainPageController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnCaiDat { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnPhanAnh { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnThongKe { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnTraCuu { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnTroGiup { get; set; }

        [Action ("BtnThongKe_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnThongKe_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnCaiDat != null) {
                btnCaiDat.Dispose ();
                btnCaiDat = null;
            }

            if (btnPhanAnh != null) {
                btnPhanAnh.Dispose ();
                btnPhanAnh = null;
            }

            if (btnThongKe != null) {
                btnThongKe.Dispose ();
                btnThongKe = null;
            }

            if (btnTraCuu != null) {
                btnTraCuu.Dispose ();
                btnTraCuu = null;
            }

            if (btnTroGiup != null) {
                btnTroGiup.Dispose ();
                btnTroGiup = null;
            }
        }
    }
}