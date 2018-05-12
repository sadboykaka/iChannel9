// This file has been autogenerated from a class added in the UI designer.

using System;
using Channel9.Core.Services;
using Channel9.Model;
using Foundation;
using UIKit;

namespace Channel9
{
	public partial class SessionCell : UITableViewCell
	{
		public SessionCell (IntPtr handle) : base (handle)
		{
		}

        public async void Configure(Session session)
        {
            titleLabel.Text = session.Title;
            tagsLabel.Text = session.TagsText;
            speakersLabel.Text = session.SpeakersText;
            if (!String.IsNullOrEmpty(session.FeaturedImage))
            {
                var bytes = await ContentService.DownloadImageArrayAsync(session.FeaturedImage);
                thumbnailImage.Image = UIImage.LoadFromData(NSData.FromArray(bytes));
            } else {
                thumbnailImage.Image = UIImage.FromBundle("noimage");
            }
        }
	}
}