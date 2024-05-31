using scripts;

namespace csharpclicker
{
    public class Building(string name, double cps, double cost)
    {
        readonly double clicksPerSecond = cps;
        readonly double baseCost = cost;
        private string _name = name;
        public string Name
        {
            get { return _name; }
            set { _name = value; MainWindow.GetMW().UpdateDisplay(); }
        }

        public int Quantity { get; set; } = 0;

        public static string[] GetBuildingTypes()
        {
            return ["Autoclicker", "Grandma", "Farm", "Factory", "Reactor"];
        }

        public static Building[] GetBuildings()
        {
            return BuildingJsonReader.GetBuildings();
        }

        public double Buy(double score, int q = 1)
        {
            double price = this.GetPrice(q);
            if (score >= price)
            {
                Quantity += q;
                return price;
            }
            else
            {
                return -1;
            }
        }

        public double GetPrice(int count = 1)
        {
            return math.buildingPrice(baseCost, Quantity + count);
        }

        public double GetClicks()
        {
            return Quantity * clicksPerSecond;

        }

    }
}
