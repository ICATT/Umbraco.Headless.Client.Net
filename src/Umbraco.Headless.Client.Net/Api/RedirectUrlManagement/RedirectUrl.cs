using Newtonsoft.Json;
using System;

namespace Umbraco.Headless.Client.Net.Api.RedirectUrlManagement
{
    public class RedirectUrl : IRedirectUrl
    {
        [JsonProperty("redirectId")]
        public Guid RedirectId { get; set; }

        [JsonProperty("originalUrl")]
        public string OriginalUrl { get; set; }

        [JsonProperty("destinationUrl")]
        public string DestinationUrl { get; set; }

        [JsonProperty("createDateUtc")]
        public DateTime CreateDateUtc { get; set; }

        [JsonProperty("contentId")]
        public int ContentId { get; set; }

        [JsonProperty("culture")]
        public string Culture { get; set; }
    }
}
