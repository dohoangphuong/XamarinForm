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
    [Register ("PhanAnhController")]
    partial class PhanAnhController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnBanDo { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnGui { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnThemAnh { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnThongTin { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView txtNoiDung { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtVitri { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnBanDo != null) {
                btnBanDo.Dispose ();
                btnBanDo = null;
            }

            if (btnGui != null) {
                btnGui.Dispose ();
                btnGui = null;
            }

            if (btnThemAnh != null) {
                btnThemAnh.Dispose ();
                btnThemAnh = null;
            }

            if (btnThongTin != null) {
                btnThongTin.Dispose ();
                btnThongTin = null;
            }

            if (txtNoiDung != null) {
                txtNoiDung.Dispose ();
                txtNoiDung = null;
            }

            if (txtVitri != null) {
                txtVitri.Dispose ();
                txtVitri = null;
            }
        }
    }
}