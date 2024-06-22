using System.IO;
using System.Text.Json;
using System.Windows;
namespace Csharpclicker
{
    internal class BuildingJsonReader
    {
        // TODO: make this a relative path probably
        static public string filePath = "C:\\src\\cookieclicker\\csharpclicker\\buildings.json";

        static private JsonDocument? GetBuildingsJsonFromFile()
        {
            try { return JsonDocument.Parse(File.ReadAllText(filePath)); }
            catch (FileNotFoundException e)
            {
                string txt = String.Format("Did you forget to make {1} absolute? {0}", e.Message, filePath);
                MessageBox.Show(txt);
            }
            return null;
        }

        static public Building[] GetBuildings()
        {
            JsonDocument? json = GetBuildingsJsonFromFile();
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
