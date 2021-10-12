using Newtonsoft.Json;
using System.Collections.Generic;

namespace Umbraco.Headless.Client.Net.Api.RedirectUrlManagement
{
    public class RedirectUrlSearchResult
    {
        [JsonProperty("searchResults")]
        public IEnumerable<RedirectUrl> SearchResults { get; set; }

        [JsonProperty("totalCount")]
        public long TotalCount { get; set; }

        [JsonProperty("pageCount")]
        public int PageCount { get; set; }

        [JsonProperty("currentPage")]
        public int CurrentPage { get; set; }
    }
}
