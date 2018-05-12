using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Channel9.Model
{
    public class Entry : IPlayableItem
	{
        public string ItemType { get; } = "Channel9.ODataModel.Entry";
		public string ID { get; set; }
		public bool HasVideo { get; set; }
		public String CurrentRating { get; set; }
		public String InQueue { get; set; }
		public String LastViewedPosition { get; set; }
		public String FarthestViewedPosition { get; set; }
		public int CommentCount { get; set; }
		public string Title { get; set; }
		public string Body { get; set; }
		public string NoHTMLBody { get; set; }
        public string CleanBody 
        {
            get {
                //var htmlData = NSData.FromString(htmlText, NSStringEncoding.UTF8) ;
                //var attr = new NSAttributedStringDocumentAttributes();
                //attr.DocumentType = NSDocumentType.HTML;
                //attr.StringEncoding = NSStringEncoding.UTF8;
                //NSError error = null;
                //NSAttributedString bodyText = new NSAttributedString( htmlData, attr, ref error);
                //episodeDetailTextView.AttributedText = bodyText;

                if (!HasVideo)
                {
                    return NoHTMLBody ?? String.Empty;
                }

                if (String.IsNullOrEmpty(Body))
                {
                    return String.Empty;
                }

                var pos = Body.IndexOf("</p>", StringComparison.Ordinal);
                var htmlText = Body.Substring(0, pos + 4);
                htmlText = Regex.Replace(htmlText, "</?(a|A).*?>", "");
                return htmlText.Replace("&nbsp;"," ").Replace("<p>", "").Replace("</p>", "").Replace("<strong>","").Replace("</strong>","");
            }
        }
		public string GroupKey { get; set; }
		public DateTime PublishedDate { get; set; }
		public string VideoPlayerPreviewImage { get; set; }
		public string LargeThumbnail { get; set; }
		public string MediumThumbnail { get; set; }
		public string SmallThumbnail { get; set; }
		public string VideoMP4High { get; set; }
		public string VideoMP4Medium { get; set; }
		public string VideoMP4Low { get; set; }

        public string ThumbnailImage {
            get {
                if (!String.IsNullOrEmpty(LargeThumbnail)) return LargeThumbnail;
                if (!String.IsNullOrEmpty(MediumThumbnail)) return MediumThumbnail;
                if (!String.IsNullOrEmpty(SmallThumbnail)) return SmallThumbnail;
                if (!String.IsNullOrEmpty(VideoPlayerPreviewImage)) return VideoPlayerPreviewImage;

				return String.Empty;
            }
        }

        public string BestVideoAvailable {
            get {
                return VideoMP4High ?? VideoMP4Medium ?? VideoMP4Low ?? String.Empty;
            }
        }

		public String VideoWMVHQ { get; set; }
		public String VideoWMV { get; set; }
		public String VideoSmooth { get; set; }
		public String VideoProgress { get; set; }
		public double? MediaLengthInSeconds { get; set; }
		public int Views { get; set; }
		public int ViewsThisMonth { get; set; }
		public int ViewsThisWeek { get; set; }
		public double Rating { get; set; }
		public int RatingCount { get; set; }
		public String Freshness { get; set; }
		public string Permalink { get; set; }
		public IList<String> Captions { get; set; }
        public string AreaId { get; set; }
	}
}
