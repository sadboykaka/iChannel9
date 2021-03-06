// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Net.Http;
using Channel9.Core.Model;
using Channel9.Core.Services;
using Foundation;
using UIKit;

namespace Channel9
{
	public partial class ShowCell : UICollectionViewCell
	{
		public ShowCell (IntPtr handle) : base (handle)
		{
		}

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
        }

        public async void Configure(Area show)
        {
            this.nameLabel.Text = show.DisplayName;
            this.dateLabel.Text = show.MostRecentEntry.ToString("dd-MM");
			imageView.Image = null;
			var byteImage = await ContentService.DownloadImageArrayAsync(show.WidescreenThumbnailImage ?? show.ThumbnailImage);
			imageView.Image = UIImage.LoadFromData(NSData.FromArray(byteImage));
        }
	}
}
