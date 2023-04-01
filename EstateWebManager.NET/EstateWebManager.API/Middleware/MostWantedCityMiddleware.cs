using EstateWebManager.API.Services;

namespace EstateWebManager.API.Middleware
{
    public class MostWantedCityMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger<MostWantedCityMiddleware> _logger;

        private ISingletonService _cityRatingService;

        public MostWantedCityMiddleware(RequestDelegate next, ILogger<MostWantedCityMiddleware> logger, ISingletonService singletonService)
        {
            _next = next;
            _logger = logger;
            _cityRatingService = singletonService;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (httpContext.Request.Query.ContainsKey("city") || httpContext.Request.RouteValues.ContainsKey("city"))
            {
                string city;
                string id = httpContext.TraceIdentifier;
                if (httpContext.Request.Query.ContainsKey("city"))
                {
                    city = httpContext.Request.Query["city"].ToString();
                }
                else
                {
                    city = httpContext.Request.RouteValues["city"].ToString();
                }
                _cityRatingService.AddRating(city);
                int rating = _cityRatingService.GetRating(city);

                _logger.LogInformation("[{TraceId}][{timeStamp}] {CityName} city rating was updated to {Rating}", id, DateTime.Now, city, rating);

                await _cityRatingService.SaveAsync();
            }

            await _next.Invoke(httpContext);
        }
    }

    public static class CityObserverMiddleware
    {
        public static IApplicationBuilder UseMostWantedCityMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MostWantedCityMiddleware>();
        }
    }
}
