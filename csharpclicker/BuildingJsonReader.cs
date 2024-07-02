using System.Text.Json;
namespace Csharpclicker
{
    static class BuildingJsonReader
    {
        static readonly string Path = "buildings.json";

        static public Building[] GetBuildings()
        {
            JsonDocument? json = JsonReader.ReadJsonFromFile(Path);
            if (json == null) { return []; }
            JsonElement.ObjectEnumerator iter = json.RootElement.EnumerateObject();
            List<Building> buildings = [];

            foreach (JsonProperty prop in iter)
            {
                string name = prop.Name;
                double cps = prop.Value.GetProperty("cps").GetDouble();
                double baseCost = prop.Value.GetProperty("baseCost").GetDouble();
                buildings.Add(new Building(name, cps, baseCost));
            }

            return buildings.ToArray();
        }
    }
}
