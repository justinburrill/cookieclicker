using scripts;

namespace csharpclicker
{
    public class Building(string name, float cps, float cost)
    {
        readonly float clicksPerSecond = cps;
        readonly float baseCost = cost;
        public string Name { get; set; } = name;

        private int Quantity { get; set; }

        public static string[] GetBuildingTypes()
        {
            return ["Autoclicker", "Grandma", "Farm", "Factory", "Reactor"];
        }

        public static Building[] GetBuildings()
        {
            string[] names = GetBuildingTypes();
            Building[] buildingList = new Building[names.Length];
            for (int i = 0; i < names.Length; i++)
            {
                string n = names[i];
            }
            return buildingList;
        }


        public double Buy(int count = 1)
        {
            return math.buildingPrice(baseCost, Quantity + count);
        }

        public float GetClicks()
        {
            return Quantity * clicksPerSecond;

        }

    }
}
