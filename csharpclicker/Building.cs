using scripts;
using System.Windows;
using System.Windows.Controls;

namespace Csharpclicker
{
    public class Building
    {
        public bool built = false;
        readonly double baseClicksPerSecond;
        readonly double baseCost;
        private TextBlock _ShopText;
        TextBlock ShopText
        {
            get { return _ShopText; }
            set
            {
                if (value.Text is null)
                {
                    throw new ArgumentNullException("boooo");
                }
                _ShopText = value;
                if (built)
                    UpdateShopText(value);
            }
        }
        readonly Button button;
        public StackPanel panel;
        public string Name { get; set; }
        int _quantity = 0;
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                ShopText = ShopItemGenerators.GenerateItemText(this);
                ((MainWindow)Application.Current.MainWindow).UpdateCPS();
            }
        }

        public Building(string name, double cps, double cost)
        {
            Name = name;
            baseCost = cost;
            baseClicksPerSecond = cps;
            _ShopText = ShopItemGenerators.GenerateItemText(this);
            button = ShopItemGenerators.GenerateBuyButton(this);
            panel = ShopItemGenerators.GeneratePanel(ShopText, button);
            built = true;

        }

        public static string[] GetBuildingTypes()
        {
            return ["Autoclicker", "Grandma", "Farm", "Factory", "Reactor"];
        }

        public static double GetCPSFromAllBuildings(Building[] buildings)
        {

            double total = 0;
            foreach (Building b in buildings)
            {
                total += b.GetTotalCPS();
            }

            return total;
        }

        public static Building[] InitBuildings()
        {
            return BuildingJsonReader.GetBuildings();
        }

        void ReloadText()
        {
            ShopText = ShopItemGenerators.GenerateItemText(this);
        }

        public static void ReloadAllText()
        {
            foreach (Building b in ((MainWindow)Application.Current.MainWindow).buildings)
            {
                b.ReloadText();
            }
        }

        void UpdateShopText(TextBlock text)
        {
            foreach (StackPanel panel in ((MainWindow)(Application.Current.MainWindow)).ShopBox.Children)
            {
                string oldText = ((TextBlock)panel.Children[0]).Text;
                if (oldText.StartsWith(Name))
                {
                    panel.Children.RemoveAt(0);
                    panel.Children.Insert(0, text);
                }
            }
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
            }
            else
            {

                MessageBox.Show("Insufficient funds broke ass");

            }
        }

        public double GetPrice(int count = 1) { return math.buildingPrice(baseCost, Quantity + count); }

        public double GetTotalCPS() { return Quantity * baseClicksPerSecond; }

        public double GetCPSperCost() { return Math.Round(baseClicksPerSecond / GetPrice(), 3); }

        public double GetCostperCPS() { return Math.Round(GetPrice() / baseClicksPerSecond); }

    }
}
