// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Net.Http;
using AVFoundation;
using AVKit;
using Channel9.Model;
using Channel9.Core.Services;
using Foundation;
using UIKit;

namespace Channel9
{
    public partial class EntryDetailViewController : UIViewController
	{
		public EntryDetailViewController (IntPtr handle) : base (handle)
		{
		}

        private void FillData()
        {
            if (Entry != null)
            {
                this.titleLabel.Text = Entry.Title;
                this.bodyLabel.Text = Entry.CleanBody;
                this.rateLabel.Text = $"Rating: {Entry.Rating.ToString("N2")}";

                var ts = TimeSpan.FromSeconds(Entry.MediaLengthInSeconds.GetValueOrDefault(0));
				var duration = ts.Hours > 0 ? $"{ts.Hours}:{ts.Minutes.ToString("00")}:{ts.Seconds.ToString("00")}" : $"{ts.Minutes}:{ts.Seconds}";

				this.playCountLabel.Text = $"Duration: {duration}";
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            FillData();
            //
            this.largeImage.Layer.CornerRadius = 25;
			this.largeImage.Layer.SetNeedsDisplay();
			this.largeImage.ClipsToBounds = true;
            this.largeImage.SetNeedsDisplay();
            LoadImage();
        }

        private async void LoadImage()
        {
            if (!String.IsNullOrEmpty(Entry.VideoPlayerPreviewImage))
            {
				var byteImage = await ContentService.DownloadImageArrayAsync(Entry.VideoPlayerPreviewImage);
				largeImage.Image = UIImage.LoadFromData(NSData.FromArray(byteImage));
			}
        }

        //AVPlayer player { get; set; }
        //AVPlayerViewController playverVc { get; set; }

        public IPlayableItem Entry { get; set; }

        partial void playButtonTapped(Foundation.NSObject sender) {
            var player = new AVPlayer( NSUrl.FromString(Entry.BestVideoAvailable));

            var playerVc = new PlayerViewController();
            playerVc.Player = player;
            //this.player = player;
            //this.playverVc = playerVc;

            PresentViewController(playerVc,true,() => {
                playerVc.StartOrResumePlay(Entry.BestVideoAvailable);  
            });
        }



	}
}
