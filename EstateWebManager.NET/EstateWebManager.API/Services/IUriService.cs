using EstateWebManager.API.Wrappers;

namespace EstateWebManager.API.Services
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route, string queryString);
    }
}
