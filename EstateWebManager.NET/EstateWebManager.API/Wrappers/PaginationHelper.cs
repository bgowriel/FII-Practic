using EstateWebManager.API.Services;

namespace EstateWebManager.API.Wrappers
{
    public class PaginationHelper
    {
        public static PagedResponse<List<T>> CreatePagedResponse<T>(List<T> pagedData, PaginationFilter validFilter, int totalRecords, IUriService uriService, string route, string queryString)
        {
            var response = new PagedResponse<List<T>>(pagedData.ToList(), validFilter.PageNumber, validFilter.PageSize);
            
            var totalPages = ((double)totalRecords / (double)validFilter.PageSize);
            var roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));

            if (validFilter.PageNumber >= 1 && validFilter.PageNumber < roundedTotalPages)
            {
                response.NextPage = (Uri?)uriService.GetPageUri(new PaginationFilter(validFilter.PageNumber + 1, validFilter.PageSize), route, queryString);
            }
            else
            {
                response.NextPage = null;
            }
            
            if (validFilter.PageNumber - 1 >= 1 && validFilter.PageNumber <= roundedTotalPages)
            {
                response.PreviousPage = (Uri?)uriService.GetPageUri(new PaginationFilter(validFilter.PageNumber - 1, validFilter.PageSize), route, queryString);
            }
            else
            {
                response.PreviousPage = null;
            }
            
            response.FirstPage = uriService.GetPageUri(new PaginationFilter(1, validFilter.PageSize), route, queryString);
            response.LastPage = uriService.GetPageUri(new PaginationFilter(roundedTotalPages, validFilter.PageSize), route, queryString);
            
            response.TotalPages = roundedTotalPages;
            response.TotalRecords = totalRecords;
            
            return response;
        }
    }
}
