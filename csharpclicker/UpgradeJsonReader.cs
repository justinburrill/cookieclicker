using System.Text.Json;
namespace Csharpclicker
{
    static class UpgradeJsonReader
    {
        static readonly string Path = "upgrades.json";

        static public Upgrade[] GetUpgrades()
        {
            JsonDocument? json = JsonReader.ReadJsonFromFile(Path);
            if (json == null) { return []; }
            JsonElement.ObjectEnumerator iter = json.RootElement.EnumerateObject();
            List<Upgrade> upgrades = [];

            foreach (JsonProperty prop in iter)
            {
                string name = prop.Name;
                string? description = prop.Value.GetProperty("description").GetString();
                if (description == null)
                {
                    throw new JsonException();
                }
                int cost = prop.Value.GetProperty("cost").GetInt32();


            }


            return upgrades.ToArray();

        }

    }
}
