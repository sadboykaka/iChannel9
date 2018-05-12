// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Channel9
{
    [Register ("SessionsViewController")]
    partial class SessionsViewController
    {
        [Outlet]
        UIKit.UIImageView bannerImage { get; set; }


        [Outlet]
        UIKit.UILabel descriptionLabel { get; set; }


        [Outlet]
        UIKit.UITextView descriptionTextView { get; set; }


        [Outlet]
        UIKit.UILabel startsLabel { get; set; }


        [Outlet]
        UIKit.UITableView tableView { get; set; }


        [Outlet]
        UIKit.UILabel titleLabel { get; set; }


        [Outlet]
        UIKit.UILabel trackLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (bannerImage != null) {
                bannerImage.Dispose ();
                bannerImage = null;
            }

            if (descriptionLabel != null) {
                descriptionLabel.Dispose ();
                descriptionLabel = null;
            }

            if (descriptionTextView != null) {
                descriptionTextView.Dispose ();
                descriptionTextView = null;
            }

            if (startsLabel != null) {
                startsLabel.Dispose ();
                startsLabel = null;
            }

            if (tableView != null) {
                tableView.Dispose ();
                tableView = null;
            }

            if (titleLabel != null) {
                titleLabel.Dispose ();
                titleLabel = null;
            }

            if (trackLabel != null) {
                trackLabel.Dispose ();
                trackLabel = null;
            }
        }
    }
}