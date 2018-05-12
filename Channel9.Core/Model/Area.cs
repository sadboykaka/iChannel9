using System;
namespace Channel9.Core.Model
{
	public class Area
	{
		public DateTime MostRecentEntry { get; set; }
		public string ID { get; set; }
		public string DisplayName { get; set; }
		public string UrlSafeName { get; set; }
		public string Description { get; set; }
		public string Type { get; set; }
		public string BannerImage { get; set; }
		public string ThumbnailImage { get; set; }
		public string WidescreenThumbnailImage { get; set; }
		public string FeedImage { get; set; }
		public string Permalink { get; set; }
	}

}
