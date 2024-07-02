using System.IO;
using System.Text.Json;

namespace Csharpclicker
{
    static class JsonReader
    {

        public static JsonDocument? ReadJsonFromFile(string filepath)
        {
            return JsonDocument.Parse(File.ReadAllText(filepath));
        }
    }
}
