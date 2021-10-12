using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Umbraco.Headless.Client.Net.Api.RedirectUrlManagement
{
    [Headers(Constants.ApiMinimumVersionHeader)]
    interface RedirectUrlManagementEndpoints
    {
        [Get("/RedirectUrlManagement/SearchRedirectUrls?searchTerm={searchTerm}&page={page}&pageSize={pageSize}")]
        Task<RedirectUrlSearchResult> GetSearchResults([Header(Constants.Headers.ProjectAlias)] string projectAlias, [Header(Constants.Headers.AcceptLanguage)] string searchTerm, int page, int pageSize);
    }
}
