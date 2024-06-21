using System.Windows;

namespace csharpclicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double CookieScore { get; set; }
        public Building[] buildings = Building.InitBuildings();

        public MainWindow()
        {
            // Setup ---------
            InitializeComponent();

            foreach (Building b in buildings)
            {
                ShopBox.Children.Add(b.panel);
            }
            // Threads -------
            //Thread updateThread = new(UpdateLoop)
            //{
            //    IsBackground = true
            //};
            Thread clickThread = new(AutoClickLoop)
            {
                IsBackground = true
            };
            //updateThread.Start();
            clickThread.Start();


        }

        //static private ShopItemGenerators[] GenerateShop(Building[] buildings)
        //{
        //    ShopItemGenerators[] list = new ShopItemGenerators[buildings.Length];
        //    for (int i = 0; i < buildings.Length; i++)
        //    {
        //        ShopItemGenerators si = new(buildings[i]);
        //        list[i] = si;
        //    }
        //    return list;
        //}


        //public void GenerateShop(Building[] buildings)
        //{
        //    ShopBox.Children.Clear();
        //    for (int i = 0; i < buildings.Length; i++)
        //    {
        //        //Grid grid = new Grid();
        //        TextBlock shopText = new() { Text = string.Format("{0} x{1}\nPrice: {2}", buildings[i].Name, buildings[i].Quantity, Math.Round(buildings[i].GetPrice())) };
        //        Button buyButton = new();
        //        buyButton.Click += BuyButton_Click;
        //        buyButton.Content = "Buy";
        //        buyButton.Name = String.Format("{0}BuyButton", buildings[i].Name);
        //        StackPanel container = new()
        //        {
        //            Height = 100,
        //            Width = 170,
        //            Children = {
        //                shopText,
        //                buyButton
        //        }
        //        };
        //        //box.MouseUp += new System.Windows.Input.MouseButtonEventHandler(BuyButton_Click);
        //        //Border divider = new()
        //        //{
        //        //    BorderBrush = new SolidColorBrush(Colors.Black),
        //        //    BorderThickness = new Thickness(.2),
        //        //};

        //        // add elements to the screen
        //        ShopBox.Children.Add(container);
        //        //ShopBox.Children.Add(divider);
        //    }
        //}


        public void ClickCookie()
        {
            CookieScore++;
        }

        private void UpdateDisplay()
        {
            throw new Exception("dont use this?");
            //scoreTB.Text = ((int)CookieScore).ToString();
            //cpsTB.Text = String.Format("{0} cps", Building.GetTotalCPS(buildings).ToString());
            //for (int i = 0; i < buildings.Length; i++)
            //{
            //    buildings[i].Update();
            //}
        }

        private void UpdateLoop()
        {
            throw new Exception("don't use this code probably");
            // i need to make it so that the buttons are not regenerated every frame
            double framerate = 4;
            int delay_ms = (int)((1 / framerate) * 1000);
            while (true)
            {
                Thread.Sleep(delay_ms);
                Dispatcher.Invoke(UpdateDisplay);
            }
        }

        private void AutoClickLoop()
        {
            while (true)
            {
                Thread.Sleep(1000);
                CookieScore += Building.GetTotalCPS(buildings);
            }
        }

        private void CookieButton_Click(object sender, RoutedEventArgs e)
        {
            ClickCookie();
        }
    }
}