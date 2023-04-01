using System.Text;

namespace EstateWebManager.API.Services
{
    public class CityRatingSingletonService : ISingletonService
    {
        public Guid Guid { get; set; } = Guid.NewGuid();

        private Dictionary<string, int> CityRatings = new Dictionary<string, int>();

        public Dictionary<string, int> GetRatings()
        {
            return CityRatings;
        }

        public void AddRating(string entity)
        {
            if (CityRatings.ContainsKey(entity))
            {
                CityRatings[entity] += 1;
            }
            else CityRatings.Add(entity, 1);
        }

        public int GetRating(string entity)
        {
            return CityRatings[entity];
        }

        public async Task SaveAsync()
        {
            StringBuilder stringBuilder = new StringBuilder("At " + DateTime.Now + " the city ratings are:\n");
            foreach (var city in CityRatings.Keys)
            {
                stringBuilder.Append("\n\tCity " + city + " has rating " + CityRatings[city]);
            }
            await File.WriteAllLinesAsync($@"{Directory.GetCurrentDirectory()}\Services\CityRatings.txt", stringBuilder.ToString().Split('\n'));
        }

    }
}
