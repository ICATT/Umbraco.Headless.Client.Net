using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Umbraco.Headless.Client.Net.Api.ExamineManagement
{
    public interface IExamineManagement
    {
        /// <summary>
        /// Search for content by term
        /// </summary>
        /// <param name="searcherName">Index name</param>
        /// <param name="query">query</param>
        /// <param name="pageIndex">Integer specifying the page number (Optional)</param>
        /// <param name="pageSize">Integer specifying the page size (Optional)</param>
        /// <returns><see cref="SearchResults"/></returns>
        Task<SearchResults> GetSearchResults(string searcherName, string query, int pageIndex = 1, int pageSize = 10);
    }
}
