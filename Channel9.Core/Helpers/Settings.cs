using System;
using Plugin.Settings.Abstractions;
using Plugin.Settings;

namespace Channel9.Core.Helpers
{
    public static class Settings
    {
		private static ISettings AppSettings
		{
			get
			{
				return CrossSettings.Current;
			}
		}

		#region Setting Constants
        private const string FavoriteShowsKey = "favorite_shows_key";
        private const string FavoriteSeriesKey = "favorite_series_key";
        private static readonly string FavoritesDefault = "[]";
        private static string LastVideoUrlKey = "last_video_url_key";
        private static string LastVideoPositionKey = "last_video_position_key";
        private static string LastVideoPositionScaleKey = "last_video_position_scale_key";
        private static string StringDefault = "";
        private static double VideoPositionDefault = 0;
        private static int TimeScaleDefault = 0;
		#endregion

		public static string FavoriteShows
		{
			get
			{
                return AppSettings.GetValueOrDefault(FavoriteShowsKey, FavoritesDefault);
			}
			set
			{
                AppSettings.AddOrUpdateValue(FavoriteShowsKey, value);
			}
		}

		public static string FavoriteSeries
		{
			get
			{
				return AppSettings.GetValueOrDefault(FavoriteSeriesKey, FavoritesDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(FavoriteSeriesKey, value);
			}
		}

        public static string LastVideoUrl
        {
            get {
                return AppSettings.GetValueOrDefault(LastVideoUrlKey, StringDefault);
            } set {
                AppSettings.AddOrUpdateValue(LastVideoUrlKey,value);
            }
        }

		public static double LastVideoPosition
		{
			get
			{
                return AppSettings.GetValueOrDefault(LastVideoPositionKey, VideoPositionDefault);
			}
			set
			{
                AppSettings.AddOrUpdateValue(LastVideoPositionKey, value);
			}
		}

		public static int LastVideoPositionScale
		{
			get
			{
                return AppSettings.GetValueOrDefault(LastVideoPositionScaleKey, TimeScaleDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(LastVideoPositionScaleKey, value);
			}
		}
	}
}
