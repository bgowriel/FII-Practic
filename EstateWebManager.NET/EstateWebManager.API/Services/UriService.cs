using EstateWebManager.API.Wrappers;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace EstateWebManager.API.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;

        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }
        
        public Uri GetPageUri(PaginationFilter filter, string route, string queryString)
        {
            var _endPointUri = new Uri(string.Concat(_baseUri, route));
            var queryMap = QueryHelpers.ParseQuery(queryString);
            var modifiedUri = new string(_endPointUri.ToString());

            foreach (var param in queryMap)
            {
                if (param.Key == "pageNumber" || param.Key == "pageSize")
                {
                    continue;
                }
                modifiedUri = QueryHelpers.AddQueryString(modifiedUri, param.Key, param.Value.ToString());
            }
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "pageNumber", filter.PageNumber.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "pageSize", filter.PageSize.ToString());
            
            return new Uri(modifiedUri);
        }
    }
}
