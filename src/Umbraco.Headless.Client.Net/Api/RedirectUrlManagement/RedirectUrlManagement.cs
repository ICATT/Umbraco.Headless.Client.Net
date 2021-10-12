using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using Umbraco.Headless.Client.Net.Api;
using Umbraco.Headless.Client.Net.Api.ExamineManagement;
using Umbraco.Headless.Client.Net.Configuration;
using Umbraco.Headless.Client.Net.Delivery;
using Umbraco.Headless.Client.Net.Delivery.Models;

namespace Umbraco.Headless.Client.Net.Api.RedirectUrlManagement
{
    internal class RedirectUrlManagement : ApiBase, IRedirectUrlService
    {
        private readonly IHeadlessConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly RefitSettings _refitSettings;
        private RedirectUrlManagementEndpoints _service;

        public RedirectUrlManagement(IHeadlessConfiguration configuration, HttpClient httpClient, RefitSettings refitSettings, ModelNameResolver modelNameResolver) : base(configuration)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _refitSettings = refitSettings;
        }

        private RedirectUrlManagementEndpoints Service =>
            _service ?? (_service = RestService.For<RedirectUrlManagementEndpoints>(_httpClient, _refitSettings));

        public Task<SearchResults> GetSearchResults(string searcherName, string query, int pageIndex = 1, int pageSize = 10)
        {
            throw new NotImplementedException();
        }

        public void Register(string url, Guid contentKey, string culture = null)
        {
            throw new NotImplementedException();
        }

        public void DeleteContentRedirectUrls(Guid contentKey)
        {
            throw new NotImplementedException();
        }

        public void Delete(IRedirectUrl redirectUrl)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public IRedirectUrl GetMostRecentRedirectUrl(string url)
        {
            throw new NotImplementedException();
        }

        public IRedirectUrl GetMostRecentRedirectUrl(string url, string culture)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IRedirectUrl> GetContentRedirectUrls(Guid contentKey)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IRedirectUrl> GetAllRedirectUrls(long pageIndex, int pageSize, out long total)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IRedirectUrl> GetAllRedirectUrls(int rootContentId, long pageIndex, int pageSize, out long total)
        {
            throw new NotImplementedException();
        }

        public async Task<RedirectUrlSearchResult> SearchRedirectUrlsAsync(string searchTerm, int pageIndex, int pageSize = 20)
        {
            var result = await Get(x => x.GetSearchResults(Configuration.ProjectAlias, searchTerm, pageIndex, pageSize)).ConfigureAwait(false);
            
            return result;
        }

        private async Task<T> Get<T>(Func<RedirectUrlManagementEndpoints, Task<T>> getResponse)
        {
            return await getResponse(Service).ConfigureAwait(false);
        }

    }
}
