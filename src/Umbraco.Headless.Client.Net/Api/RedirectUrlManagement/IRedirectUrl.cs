using Newtonsoft.Json;
using System;

namespace Umbraco.Headless.Client.Net.Api.RedirectUrlManagement
{
    public interface IRedirectUrl
    {
        [JsonProperty("redirectId")]
        Guid RedirectId { get; set; }

        [JsonProperty("originalUrl")]
        string OriginalUrl { get; set; }

        [JsonProperty("destinationUrl")]
        string DestinationUrl { get; set; }

        [JsonProperty("createDateUtc")]
        DateTime CreateDateUtc { get; set; }

        [JsonProperty("contentId")]
        int ContentId { get; set; }

        [JsonProperty("culture")]
        string Culture { get; set; }
    }
}
