using System.Windows;
using System.Windows.Controls;

namespace csharpclicker
{
    abstract internal class ShopItemGenerators
    {
        static public StackPanel GeneratePanel(TextBlock text, Button button)
        {
            return new StackPanel
            {
                Height = 100,
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
            string txt = string.Format("{0} x{1}\nPrice: {2}", building.Name, building.Quantity, Math.Round(building.GetPrice()));
            TextBlock textBlock = new()
            {
                Text = txt
            };

            return textBlock;
        }

    }
}
