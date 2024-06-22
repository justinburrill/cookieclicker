using System.Windows;
using System.Windows.Controls;

namespace Csharpclicker
{
    abstract internal class ShopItemGenerators
    {
        static public StackPanel GeneratePanel(TextBlock text, Button button)
        {
            return new StackPanel
            {
                Height = 75,
                Width = 170,
                Children = {
                    text,
                    button
                }
            };
        }
        //static private StackPanel GenerateShopItem(Building b)
        //{
        //    return new StackPanel
        //    {
        //        Height = 100,
        //        Width = 170,
        //        Children = {
        //            GenerateItemText(b),
        //            GenerateBuyButtonText(b),
        //        }
        //    };
        //}

        static public Button GenerateBuyButton(Building building)
        {
            Button button = new()
            {
                Content = "Buy",
                Name = String.Format("{0}BuyButton", building.Name),
            };
            button.Click += BuyButton_Click;

            return button;
        }

        private static void BuyButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            string buildingName = scripts.strings.removeSuffix(((Button)sender).Name, "BuyButton");
            Building building = ((MainWindow)Application.Current.MainWindow).buildings.Single(b => b.Name == buildingName);
            building.Buy(1);
        }

        static public TextBlock GenerateItemText(Building building)
        {
            string line1 = string.Format("{0} x{1}", building.Name, building.Quantity);
            string line2 = string.Format("Price: {0}", (int)building.GetPrice());
            string line3 = string.Format("CPS/$: {0} $/CPS: {1}", building.GetCPSperCost(), building.GetCostperCPS());
            TextBlock textBlock = new()
            {
                Text = line1 + "\n" + line2 + "\n" + line3
            };

            return textBlock;
        }

    }
}
