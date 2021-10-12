using Refit;
using System.Threading.Tasks;

namespace Umbraco.Headless.Client.Net.Api.ExamineManagement
{
    [Headers(Constants.ApiMinimumVersionHeader)]
    interface ExamineManagementEndpoints
    {
        [Get("/ExamineManagement/GetSearchResults?searcherName={externalIndex}&query={query}&pageIndex={pageIndex}&pageSize={pageSize}")]
        Task<SearchResults> GetSearchResults([Header(Constants.Headers.ProjectAlias)] string projectAlias, [Header(Constants.Headers.AcceptLanguage)] string externalIndex, string query, int pageIndex, int pageSize);

    }
}
