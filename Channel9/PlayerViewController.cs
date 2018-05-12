using System;
using AVFoundation;
using AVKit;
using Foundation;
using UIKit;

namespace Channel9
{
    public class PlayerViewController : AVPlayerViewController, IAVPlayerViewControllerDelegate
    {
        public PlayerViewController()
        {
        }

        private Boolean videoCompleted = false;

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            NSNotificationCenter.DefaultCenter.AddObserver( AVPlayerItem.DidPlayToEndTimeNotification,(obj) => {
                videoCompleted = true;
                DismissViewController(true,null);                
            });
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            NSNotificationCenter.DefaultCenter.RemoveObserver(this);
            if (videoCompleted)
            {
                Core.Helpers.Settings.LastVideoUrl = String.Empty;
                Core.Helpers.Settings.LastVideoPosition = 0;
            } else {
                Core.Helpers.Settings.LastVideoUrl = CurrentVideoUrl; 
                Core.Helpers.Settings.LastVideoPosition = Player.CurrentTime.Seconds;
                Core.Helpers.Settings.LastVideoPositionScale = Player.CurrentTime.TimeScale;
            }
        }

        private string CurrentVideoUrl;

        public void StartOrResumePlay(String videoUrl)
        {
            CurrentVideoUrl = videoUrl;
            if (CurrentVideoUrl == Core.Helpers.Settings.LastVideoUrl && Core.Helpers.Settings.LastVideoPosition > 0 && Core.Helpers.Settings.LastVideoPositionScale != 0)
            {
                ShowResumeOrPlayOptions();
            } else {
				Player.Play();
			}
            videoCompleted = false;
        }

        private void DoResume()
        {
			Player.Seek(CoreMedia.CMTime.FromSeconds(Core.Helpers.Settings.LastVideoPosition, Core.Helpers.Settings.LastVideoPositionScale), (finished) => {
				Player.Play();
			});
        }

        private void ShowResumeOrPlayOptions()
        {
			//Create Alert
			var resumeOrStartAlertController = UIAlertController.Create("Playback Options", "How would you like to playback this video?", UIAlertControllerStyle.Alert);

			//Add Actions
            resumeOrStartAlertController.AddAction(UIAlertAction.Create("Resume Playback", UIAlertActionStyle.Default, alert => DoResume()));
            resumeOrStartAlertController.AddAction(UIAlertAction.Create("Start from Begining", UIAlertActionStyle.Default, alert => Player.Play()));

			//Present Alert
			PresentViewController(resumeOrStartAlertController, true, null);

        }

    }
}
