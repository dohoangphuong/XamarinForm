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
	[Register ("GrowRowTableCell")]
	partial class GrowRowTableCell
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel CellDescription { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView CellImage { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel CellTitle { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (CellDescription != null) {
				CellDescription.Dispose ();
				CellDescription = null;
			}
			if (CellImage != null) {
				CellImage.Dispose ();
				CellImage = null;
			}
			if (CellTitle != null) {
				CellTitle.Dispose ();
				CellTitle = null;
			}
		}
	}
}
