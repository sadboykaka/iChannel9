using System;
using System.Collections.Generic;
using Channel9.Core.Model;
using System.Linq;
using Newtonsoft.Json;

namespace Channel9.Core.Services
{
    public static class FavoritesService
    {
        public static Boolean FavoritesDirty { get; set; } = true;

        private static List<Area> shows;
        public static List<Area> Shows 
        { 
            get {
                if (shows == null)
                {
                    shows = JsonConvert.DeserializeObject<List<Area>>(Helpers.Settings.FavoriteShows);
                }
                return shows;
            }
        }
        private static List<Area> series;
        public static List<Area> Series
        {
            get
            {
                if (series == null)
                {
                    series = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Area>>(Helpers.Settings.FavoriteSeries);
                }
                return series;
            }
        }

        public static Boolean AddFavoriteShow(Area show)
        {
            if (Shows.Any(s => s.ID == show.ID)) return false;

			Shows.Add(show);
            Helpers.Settings.FavoriteShows = JsonConvert.SerializeObject(Shows);
			FavoritesDirty = true;
			return true;
        }

        public static Boolean RemoveFavoriteShow(Area show)
		{
            var toDelete = Shows.FirstOrDefault(s => s.ID == show.ID);
            if (toDelete == null) return false;

			Shows.Remove(toDelete);
			Helpers.Settings.FavoriteShows = JsonConvert.SerializeObject(Shows);
			FavoritesDirty = true;
			return true;
		}

        public static Boolean AddFavoriteSerie(Area serie)
		{
            if (Series.Any(s => s.ID == serie.ID)) return false;

			Series.Add(serie);
            Helpers.Settings.FavoriteSeries = JsonConvert.SerializeObject(Series);
			FavoritesDirty = true;
			return true;
		}

        public static Boolean RemoveFavoriteSerie(Area serie)
		{
			var toDelete = Series.FirstOrDefault(s => s.ID == serie.ID);
            if (toDelete == null) return false;

            Series.Remove(toDelete);
            Helpers.Settings.FavoriteSeries = JsonConvert.SerializeObject(Series);
            FavoritesDirty = true;
            return true;
		}

	}
}
