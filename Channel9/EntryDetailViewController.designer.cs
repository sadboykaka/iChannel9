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
    [Register ("EntryDetailViewController")]
    partial class EntryDetailViewController
    {
        [Outlet]
        UIKit.UILabel bodyLabel { get; set; }


        [Outlet]
        UIKit.UIImageView largeImage { get; set; }


        [Outlet]
        UIKit.UIButton playButton { get; set; }


        [Outlet]
        UIKit.UILabel playCountLabel { get; set; }


        [Outlet]
        UIKit.UILabel rateLabel { get; set; }


        [Outlet]
        UIKit.UILabel titleLabel { get; set; }


        [Action ("playButtonTapped:")]
        partial void playButtonTapped (Foundation.NSObject sender);

        void ReleaseDesignerOutlets ()
        {
            if (bodyLabel != null) {
                bodyLabel.Dispose ();
                bodyLabel = null;
            }

            if (largeImage != null) {
                largeImage.Dispose ();
                largeImage = null;
            }

            if (playButton != null) {
                playButton.Dispose ();
                playButton = null;
            }

            if (playCountLabel != null) {
                playCountLabel.Dispose ();
                playCountLabel = null;
            }

            if (rateLabel != null) {
                rateLabel.Dispose ();
                rateLabel = null;
            }

            if (titleLabel != null) {
                titleLabel.Dispose ();
                titleLabel = null;
            }
        }
    }
}