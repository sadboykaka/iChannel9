using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Channel9.Core.Model;
using Channel9.Model;
using Newtonsoft.Json;

namespace Channel9.Core.Services
{

	public class ContentResult<T>
	{
        [JsonProperty("odata.metadata")]
		public string OdataMetadata { get; set; }

		[JsonProperty("value")]
		public IList<T> Value { get; set; }

        [JsonProperty("odata.nextLink")]
        public string NextLink { get; set; }
	}

    public class ContentService
    {
        public static int PageSize = 25;

        private string baseUrl = "https://channel9.msdn.com/odata/";
        public ContentService()
        {
        }

        public static async Task<Byte[]> DownloadImageArrayAsync(string url)
        {
            if (String.IsNullOrEmpty(url))
            {
                return new byte[] { };
            }
            using (var httpClient = new HttpClient())
			{
				var byteImage = await httpClient.GetByteArrayAsync(url);
                return byteImage;
			}
        }

        public async Task<List<Featured>> GetFeatured()
        {
            var result = new List<Featured>();

            var url = $"{baseUrl}Featured";

            using(var httpClient = new HttpClient()) 
            {
                var jsonResult = await httpClient.GetStringAsync (url);
                var content = JsonConvert.DeserializeObject<ContentResult<Featured>>(jsonResult);
                result = content.Value.ToList();
            }

            return result;
        }


		public async Task<List<Area>> GetShows(int skip = 0)
		{
			var result = new List<Area>();

            var url = skip == 0 ? $"{baseUrl}/Areas?$top=25&$filter=Type eq 'Shows'&$orderby=MostRecentEntry desc" : $"{baseUrl}/Areas?$skip={skip}&$filter=Type eq 'Shows'&$orderby=MostRecentEntry desc";

			using (var httpClient = new HttpClient())
			{
				var jsonResult = await httpClient.GetStringAsync(url);
				var content = JsonConvert.DeserializeObject<ContentResult<Area>>(jsonResult);
				result = content.Value.ToList();
			}

			return result;
		}

		public async Task<List<Area>> GetSeries(int skip = 0)
		{
			var result = new List<Area>();

            var url = skip == 0 ?  $"{baseUrl}/Areas?$top=25&$filter=Type eq 'Series'&$orderby=MostRecentEntry desc" : $"{baseUrl}/Areas?$skip={skip}&$filter=Type eq 'Series'&$orderby=MostRecentEntry desc";

			using (var httpClient = new HttpClient())
			{
				var jsonResult = await httpClient.GetStringAsync(url);
				var content = JsonConvert.DeserializeObject<ContentResult<Area>>(jsonResult);
				result = content.Value.ToList();
			}

			return result;
		}

		public async Task<List<Event>> GetEvents()
		{
			var result = new List<Event>();
			var url = $"{baseUrl}/Events?$top=25&$orderby=Starts desc";

            using (var httpClient = new HttpClient())
			{
				var jsonResult = await httpClient.GetStringAsync(url);
				var content = JsonConvert.DeserializeObject<ContentResult<Event>>(jsonResult);
                result = content.Value.OrderBy(e => e.StatusSort).ToList();
			}

            return result;
		}

        public async Task<List<Session>> GetSessions(Event evento)
        {
            var result = new List<Session>();
            var skipCount = 0;
            var moreData = true;
            using(var httpClient = new HttpClient())
            {
				while (moreData)
				{
                    var url = $"{baseUrl}/Sessions?$skip={skipCount}&$filter=Event/ID eq guid'{evento.ID}'&$expand=Speakers,Tags";
					var jsonResult = await httpClient.GetStringAsync(url);
                    var content = JsonConvert.DeserializeObject<ContentResult<Session>>(jsonResult);
                    result.AddRange(content.Value);
                    skipCount += 25;
                    moreData = ( content.Value.Count > 0 );
				}
			}
            return result;
		}

        public async Task<Dictionary<String,List<IPlayableItem>>> GetHomeScreenData()
		{
			var result = new Dictionary<String, List<IPlayableItem>>();
            result.Add("Featured", (await GetFeatured()).Select(f => f as IPlayableItem).ToList());
			foreach (var show in FavoritesService.Shows)
			{
				var entries = await GetEntriesByArea(show.ID, 5);
				entries.ForEach((e) => e.AreaId = show.ID);
                result.Add(show.DisplayName, entries.Select(e => e as IPlayableItem).ToList());
			}
            foreach (var serie in FavoritesService.Series)
			{
				var entries = await GetEntriesByArea(serie.ID, 5);
				entries.ForEach((e) => e.AreaId = serie.ID);
                result.Add(serie.DisplayName, entries.Select(e => e as IPlayableItem).ToList());
			}

			return result; 
		}

        public async Task<List<Entry>> GetRecentShows()
        {
            var result = new List<Entry>();
            foreach (var show in FavoritesService.Shows)
            {
                var entries = await GetEntriesByArea(show.ID, 5);
                entries.ForEach( (e) => e.AreaId = show.ID );
                result.AddRange(entries);
            }
            return result; // GetEntriesByArea("d4c25330-afa4-4396-91a7-a66d012406c9", 5); 
        }

        public async Task<List<Entry>> GetRecentSeries()
		{
			var result = new List<Entry>();
			foreach (var show in FavoritesService.Series)
			{
				var entries = await GetEntriesByArea(show.ID, 5);
				entries.ForEach((e) => e.AreaId = show.ID);
				result.AddRange(entries);
			}
			return result; // GetEntriesByArea("d4c25330-afa4-4396-91a7-a66d012406c9", 5); 
		}

		public async Task<List<Entry>> GetEntriesByArea(string area, int count = 25)
        {
			var result = new List<Entry>();

            var url = $"{baseUrl}/Entries?$top={count}&$filter=Area/ID eq guid'{area}'&$orderby=Freshness desc";

			using (var httpClient = new HttpClient())
			{
				var jsonResult = await httpClient.GetStringAsync(url);
				var content = JsonConvert.DeserializeObject<ContentResult<Entry>>(jsonResult);
				result = content.Value.ToList();
			}

			return result;
        }
	}
}
