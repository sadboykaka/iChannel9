using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Channel9.Model
{
    public class Session : IPlayableItem
	{
        public string ItemType { get; } = "Channel9.ODataModel.Session";
		public string ID { get; set; }
		public bool HasVideo { get; set; }
		public String CurrentRating { get; set; }
        public String InQueue { get; set; }
		public String LastViewedPosition { get; set; }
		public String FarthestViewedPosition { get; set; }
		public int CommentCount { get; set; }
		public string Code { get; set; }
		public String SessionType { get; set; }
		public String Level { get; set; }
		public String Track { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string NoHTMLDescription { get; set; }
		public string Room { get; set; }
		public DateTime LastUpdated { get; set; }
		public DateTime? Starts { get; set; }
		public DateTime? Ends { get; set; }
		public String VideoPlayerPreviewImage { get; set; }
		public String FeaturedImage { get; set; }
		public string Thumbnail { get; set; }

		public string ThumbnailImage
		{
			get
			{
                if (!String.IsNullOrEmpty(FeaturedImage)) return FeaturedImage;
                if (!String.IsNullOrEmpty(VideoPlayerPreviewImage)) return VideoPlayerPreviewImage;
                if (!String.IsNullOrEmpty(Thumbnail)) return Thumbnail;

				return String.Empty;
			}
		}

		public String Slides { get; set; }
		public String ZipFile { get; set; }
		public String VideoMP4High { get; set; }
		public String VideoMP4Medium { get; set; }
		public String VideoMP4Low { get; set; }
		public string VideoWMVHQ { get; set; }
		public String VideoWMV { get; set; }
		public String VideoSmooth { get; set; }
		public String VideoProgress { get; set; }
		public int Views { get; set; }
		public int ViewsThisMonth { get; set; }
		public int ViewsThisWeek { get; set; }
		public double Rating { get; set; }
		public double RatingCount { get; set; }
		public String Freshness { get; set; }
		public string Permalink { get; set; }
		public double? MediaLengthInSeconds { get; set; }
		public IList<String> Captions { get; set; }
        public IList<Speaker> Speakers;
        public IList<Tag> Tags;
		public DateTime PublishedDate { get; set; }

		public string CleanBody
		{
			get
			{
				if (!HasVideo)
				{
					return String.Empty;
				}

				if (String.IsNullOrEmpty(Description))
				{
					return String.Empty;
				}
                var pos = Description.IndexOf("</p>", StringComparison.Ordinal);
				var htmlText = Description.Substring(0, pos + 4);
				htmlText = Regex.Replace(htmlText, "</?(a|A).*?>", "");
				return htmlText.Replace("&nbsp;", " ").Replace("<p>", "").Replace("</p>", "").Replace("<strong>", "").Replace("</strong>", "");
			}
		}

        public String TagsText
        {
            get {
                if (Tags == null || Tags.Count == 0)
                {
                    return String.Empty;
                }
                return String.Join(",", Tags.Select(t => t.DisplayName));
            }
        }
		public String SpeakersText
		{
			get
			{
				if (Speakers == null || Speakers.Count == 0)
				{
					return String.Empty;
				}
                return String.Join(",", Speakers.Select(s => s.FullName));
			}
		}

        public string BestVideoAvailable => VideoMP4High ?? VideoMP4Medium ?? VideoMP4Low ?? String.Empty;
    }
}
