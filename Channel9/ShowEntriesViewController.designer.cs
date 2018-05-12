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
    [Register ("ShowEntriesViewController")]
    partial class ShowEntriesViewController
    {
        [Outlet]
        UIKit.UIImageView bannerImage { get; set; }


        [Outlet]
        UIKit.UILabel durationLabel { get; set; }


        [Outlet]
        UIKit.UILabel episodeDescriptionLabel { get; set; }


        [Outlet]
        UIKit.UITextView episodeDetailTextView { get; set; }


        [Outlet]
        UIKit.UITableView listView { get; set; }


        [Outlet]
        UIKit.UIButton playButton { get; set; }


        [Outlet]
        UIKit.UILabel ratingLabel { get; set; }


        [Outlet]
        UIKit.UILabel showTitleLabel { get; set; }


        [Outlet]
        UIKit.UILabel viewCountLabel { get; set; }


        [Action ("playButtonTapped:")]
        partial void playButtonTapped (Foundation.NSObject sender);

        void ReleaseDesignerOutlets ()
        {
            if (bannerImage != null) {
                bannerImage.Dispose ();
                bannerImage = null;
            }

            if (durationLabel != null) {
                durationLabel.Dispose ();
                durationLabel = null;
            }

            if (episodeDescriptionLabel != null) {
                episodeDescriptionLabel.Dispose ();
                episodeDescriptionLabel = null;
            }

            if (episodeDetailTextView != null) {
                episodeDetailTextView.Dispose ();
                episodeDetailTextView = null;
            }

            if (listView != null) {
                listView.Dispose ();
                listView = null;
            }

            if (playButton != null) {
                playButton.Dispose ();
                playButton = null;
            }

            if (ratingLabel != null) {
                ratingLabel.Dispose ();
                ratingLabel = null;
            }

            if (showTitleLabel != null) {
                showTitleLabel.Dispose ();
                showTitleLabel = null;
            }

            if (viewCountLabel != null) {
                viewCountLabel.Dispose ();
                viewCountLabel = null;
            }
        }
    }
}