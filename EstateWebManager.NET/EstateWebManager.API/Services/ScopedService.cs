namespace EstateWebManager.API.Services
{
    public class ScopedService : IScopedService
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
    }
}
