using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using Umbraco.Headless.Client.Net.Api;
using Umbraco.Headless.Client.Net.Api.ExamineManagement;
using Umbraco.Headless.Client.Net.Api.RedirectUrlManagement;
using Umbraco.Headless.Client.Net.Configuration;
using Umbraco.Headless.Client.Net.Delivery.Models;

namespace Umbraco.Headless.Client.Net.Delivery
{
    internal class ApiManagement : ApiBase
    {
        private readonly IHeadlessConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly RefitSettings _refitSettings;
        private RedirectUrlManagementEndpoints _service;

        public ApiManagement(IHeadlessConfiguration configuration, HttpClient httpClient, RefitSettings refitSettings, ModelNameResolver modelNameResolver) : base(configuration)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _refitSettings = refitSettings;
        }

        private RedirectUrlManagementEndpoints GetService()
        {
            var baseUrl = Constants.Urls.BaseBackofficeUrl.Replace("{ProjectAlias}", _configuration.ProjectAlias);
            _httpClient.BaseAddress = new Uri(baseUrl);
            return _service ?? (_service = RestService.For<RedirectUrlManagementEndpoints>(_httpClient, _refitSettings));
        }

    }
}
