namespace EstateWebManager.API.Services
{
    public interface ISingletonService : IServiceLifetime
    {
        public Dictionary<string, int> GetRatings();

        public void AddRating(string entity);

        public int GetRating(string entity);

        public Task SaveAsync();
    }
}
