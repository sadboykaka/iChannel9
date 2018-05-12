using System;
namespace Channel9.Model
{
    public interface IPlayableItem
    {
        string Title { get; set; }
		string CleanBody { get;  }
		double? MediaLengthInSeconds { get; set; }
		double Rating { get; set; }
        string VideoPlayerPreviewImage { get; set; }
        string BestVideoAvailable { get; }
        string ItemType { get; }
        string ThumbnailImage { get; }
	}
}
