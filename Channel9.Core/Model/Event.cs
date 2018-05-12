using System;
namespace Channel9.Core.Model
{
	public class Event
	{
		public bool IsLiveOnHomepage { get; set; }
		public string ID { get; set; }
		public string EventGroup { get; set; }
		public string EventRegion { get; set; }
		public string UrlSafeName { get; set; }
		public string DisplayName { get; set; }
		public string Description { get; set; }
		public string Location { get; set; }
		public DateTime Starts { get; set; }
		public DateTime Ends { get; set; }
		public string ExternalLink { get; set; }
		public string BannerImage { get; set; }
		public string ThumbnailImage { get; set; }
		public string WidescreenThumbnailImage { get; set; }
		public string SmallThumbnailImage { get; set; }
		public string FeedImage { get; set; }
		public string Permalink { get; set; }
		public string LiveHLSLink { get; set; }
		public string LiveIFrameLink { get; set; }

        public string Status 
        {
            get {
                if (IsLiveOnHomepage)
                {
                    return "Live";
                }
                if (DateTime.Now.Date > Ends.Date)
                {
                    return "Recent";
                } else
                    return "Upcoming";
            }
        }

		public string StatusSort
		{
			get
			{
				if (IsLiveOnHomepage)
				{
					return "1";
				}
				if (DateTime.Now.Date > Ends.Date)
				{
					return "2";
				}
				else
					return "3";
			}
		}
	}
}
