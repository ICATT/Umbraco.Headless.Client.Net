using Umbraco.Headless.Client.Net.Api.RedirectUrlManagement;

namespace Umbraco.Headless.Client.Net.Delivery
{
    public interface IApiManagementService
    {
        /// <summary>
        /// Gets the Content part of the Content Delivery API
        /// </summary>
        IRedirectUrlService RedirectUrlService { get; }

    }
}
