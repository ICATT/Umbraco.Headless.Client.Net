using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Umbraco.Headless.Client.Net.Api.RedirectUrlManagement;
using Umbraco.Headless.Client.Net.Configuration;
using Umbraco.Headless.Client.Net.Delivery;
using Umbraco.Headless.Client.Net.Security;

namespace Umbraco.Headless.Client.Net.Api
{
    public class ApiManagementService : IApiManagementService
    {
        /// <summary>
        /// Initializes a new instance of the ContentDeliveryService class
        /// </summary>
        /// <param name="projectAlias">Alias of the Project</param>
        public ApiManagementService(string projectAlias) : this(new HeadlessConfiguration(projectAlias))
        { }

        /// <summary>
        /// Initializes a new instance of the ContentDeliveryService class
        /// </summary>
        /// <param name="projectAlias">Alias of the Project</param>
        /// <param name="apiKey">Api Key</param>
        public ApiManagementService(string projectAlias, string apiKey) : this(new ApiKeyBasedConfiguration(projectAlias, apiKey))
        { }

        /// <summary>
        /// Initializes a new instance of the ContentDeliveryService class
        /// </summary>
        /// <param name="projectAlias">Alias of the Project</param>
        /// <param name="username">Umbraco Backoffice Username</param>
        /// <param name="password">Umbraco Backoffice User Password</param>
        public ApiManagementService(string projectAlias, string username, string password) : this(new PasswordBasedConfiguration(projectAlias, username, password))
        { }

        /// <summary>
        /// Initializes a new instance of the ContentDeliveryService class
        /// </summary>
        /// <remarks>
        /// When passing in your own HttpClient you are responsible for setting the authentication headers
        /// </remarks>
        /// <param name="projectAlias">Alias of the Project</param>
        /// <param name="httpClient">Reference to the <see cref="HttpClient"/></param>
        public ApiManagementService(string projectAlias, HttpClient httpClient) : this(new HeadlessConfiguration(projectAlias), httpClient)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ContentDeliveryService class
        /// </summary>
        /// <param name="configuration">Reference to the <see cref="IHeadlessConfiguration"/></param>
        public ApiManagementService(IHeadlessConfiguration configuration) : this(configuration, _ => { })
        { }

        /// <summary>
        /// Initializes a new instance of the ContentDeliveryService class
        /// </summary>
        /// <param name="configuration">Reference to the <see cref="IPasswordBasedConfiguration"/></param>
        public ApiManagementService(IPasswordBasedConfiguration configuration) : this(configuration, _ => { })
        {
        }

        /// <summary>
        /// Initializes a new instance of the ContentDeliveryService class
        /// </summary>
        /// <param name="configuration">Reference to the <see cref="IApiKeyBasedConfiguration"/></param>
        public ApiManagementService(IApiKeyBasedConfiguration configuration) : this(configuration, _ => { })
        {
        }

        /// <summary>
        /// Initializes a new instance of the ContentDeliveryService class
        /// </summary>
        /// <param name="configuration">Reference to the <see cref="IHeadlessConfiguration"/></param>
        /// <param name="configureHttpClient">A delegate to configure the <see cref="HttpClient"/>.</param>
        public ApiManagementService(IHeadlessConfiguration configuration, Action<HttpClient> configureHttpClient)
        {
            HttpMessageHandler httpMessageHandler = null;
            if (configuration is IPasswordBasedConfiguration passwordBasedConfiguration)
            {
                var authenticationService = new AuthenticationService(configuration);
                var tokenResolver = new UserPasswordAccessTokenResolver(passwordBasedConfiguration.Username,
                    passwordBasedConfiguration.ProjectAlias, authenticationService);
                httpMessageHandler = new AuthenticatedHttpClientHandler(tokenResolver);
            }

            var httpClient = httpMessageHandler == null ? new HttpClient() : new HttpClient(httpMessageHandler, true);
            var baseUrl = Constants.Urls.BaseBackofficeUrl.Replace("{ProjectAlias}", configuration.ProjectAlias);
            httpClient.BaseAddress = new Uri(baseUrl);
            httpClient.DefaultRequestHeaders.UserAgent.Add(GetProductInfoHeader());

            if (configuration is IApiKeyBasedConfiguration apiKeyBasedConfiguration)
                httpClient.DefaultRequestHeaders.Add(Constants.Headers.ApiKey, apiKeyBasedConfiguration.Token);

            if (configureHttpClient != null)
                configureHttpClient(httpClient);

            var modelNameResolver = new ModelNameResolver();

            var refitSettings = CreateRefitSettings(configuration, modelNameResolver);
            RedirectUrlService = new RedirectUrlManagement.RedirectUrlManagement(configuration, httpClient, refitSettings, modelNameResolver);
        }

        /// <summary>
        /// Initializes a new instance of the ContentDeliveryService class
        /// </summary>
        /// <remarks>
        /// When passing in your own HttpClient you are responsible for setting the authentication headers
        /// </remarks>
        /// <param name="configuration">Reference to the <see cref="IHeadlessConfiguration"/></param>
        /// <param name="httpClient">Reference to the <see cref="HttpClient"/></param>
        public ApiManagementService(IHeadlessConfiguration configuration, HttpClient httpClient)
        {
            var modelNameResolver = new ModelNameResolver();
            var refitSettings = CreateRefitSettings(configuration, modelNameResolver);

            RedirectUrlService = new RedirectUrlManagement.RedirectUrlManagement(configuration, httpClient, refitSettings, modelNameResolver);
        }

        public IRedirectUrlService RedirectUrlService { get; }

        private static RefitSettings CreateRefitSettings(IHeadlessConfiguration configuration, ModelNameResolver modelNameResolver)
        {
            return new RefitSettings();
        }

        private static ProductInfoHeaderValue GetProductInfoHeader() =>
            new ProductInfoHeaderValue("UmbracoHeartcoreNetClient", Constants.GetVersion());
        
    }
}
