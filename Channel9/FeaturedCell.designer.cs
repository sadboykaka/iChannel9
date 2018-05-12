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
    [Register ("FeaturedCell")]
    partial class FeaturedCell
    {
        [Outlet]
        UIKit.UILabel labelDescription { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel labelCaption { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (imageView != null) {
                imageView.Dispose ();
                imageView = null;
            }

            if (labelCaption != null) {
                labelCaption.Dispose ();
                labelCaption = null;
            }

            if (labelDescription != null) {
                labelDescription.Dispose ();
                labelDescription = null;
            }
        }
    }
}