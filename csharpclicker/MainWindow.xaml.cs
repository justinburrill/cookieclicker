using System.Windows;
using System.Windows.Controls;

namespace csharpclicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow GetMW()
        {
            return (MainWindow)Application.Current.MainWindow;
        }
        public double CookieScore { get; set; }
        Building[] buildings = Building.GetBuildings();

        public MainWindow()
        {
            InitializeComponent();
            GenerateShop(buildings);
        }


        public void GenerateShop(Building[] buildings)
        {
            for (int i = 0; i < buildings.Length; i++)
            {
                //Grid grid = new Grid();
                TextBlock shopText = new() { Text = string.Format("{0} x{1}\nPrice: {2}", buildings[i].Name, buildings[i].Quantity, Math.Round(buildings[i].GetPrice())) };
                Button buyButton = new();
                buyButton.Click += BuyButton_Click;
                buyButton.Content = "Buy";
                buyButton.Name = String.Format("{0}BuyButton", buildings[i].Name);
                StackPanel container = new()
                {
                    Height = 100,
                    Width = 170,
                    Children = {
                        shopText,
                        buyButton
                }
                };
                //box.MouseUp += new System.Windows.Input.MouseButtonEventHandler(BuyButton_Click);
                //Border divider = new()
                //{
                //    BorderBrush = new SolidColorBrush(Colors.Black),
                //    BorderThickness = new Thickness(.2),
                //};

                // add elements to the screen
                ShopBox.Children.Add(container);
                //ShopBox.Children.Add(divider);
            }
        }


        public void ClickCookie()
        {
            CookieScore++;
            UpdateDisplay();
        }

        private void BuyButton_Click(object sender, EventArgs e)
        {
            string buildingName = scripts.strings.removeSuffix(((Button)sender).Name, "BuyButton");
            foreach (Building b in buildings)
            {
                if (b.Name.Equals(buildingName))
                {
                    double result = b.Buy(CookieScore, 1);
                    if (result == -1)
                    {
                        MessageBox.Show("Insufficient funds broke ass");
                    }
                    else
                    {
                        CookieScore = result;
                    }
                }
            }
        }

        public void UpdateDisplay()
        {
            scoreTB.Text = ((int)CookieScore).ToString();
        }

        private void CookieButton_Click(object sender, RoutedEventArgs e)
        {
            ClickCookie();
        }
    }
}