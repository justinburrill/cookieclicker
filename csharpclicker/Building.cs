using scripts;
using System.Windows;
using System.Windows.Controls;

namespace csharpclicker
{
    public class Building
    {
        readonly double baseClicksPerSecond;
        readonly double baseCost;
        TextBlock text;
        Button button;
        public readonly StackPanel panel;
        public string Name { get; set; }
        int _quantity = 0;
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                text = ShopItemGenerators.GenerateItemText(this);
            }
        }

        public Building(string name, double cps, double cost)
        {
            Name = name;
            baseCost = cost;
            baseClicksPerSecond = cps;
            text = ShopItemGenerators.GenerateItemText(this);
            button = ShopItemGenerators.GenerateBuyButton(this);
            panel = ShopItemGenerators.GeneratePanel(text, button);

        }

        public static string[] GetBuildingTypes()
        {
            return ["Autoclicker", "Grandma", "Farm", "Factory", "Reactor"];
        }

        public static double GetTotalCPS(Building[] buildings)
        {

            double total = 0;
            foreach (Building b in buildings)
            {
                total += b.GetCPS();
            }

            return total;
        }

        public static Building[] InitBuildings()
        {
            return BuildingJsonReader.GetBuildings();
        }

        public void Buy(int q = 1)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            double score = window.CookieScore;
            double price = GetPrice(q);

            if (score >= price)
            {
                Quantity += q;
                ((MainWindow)Application.Current.MainWindow).CookieScore -= price;
                MessageBox.Show(String.Format("Successful purchase. You were charged {0}", price));
            }
            else
            {

                MessageBox.Show("Insufficient funds broke ass");

            }
        }
        public double GetPrice(int count = 1)
        {
            return math.buildingPrice(baseCost, Quantity + count);
        }

        public double GetCPS()
        {
            return Quantity * baseClicksPerSecond;

        }

    }
}
