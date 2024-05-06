using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace csharpclicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        float cookieScore = 0;
        public MainWindow()
        {
            InitializeComponent();
            Building[] building = Building.GetBuildings();
            GenerateShop();
        }


        public void GenerateShop(/*put building list in here*/)
        {
            Building[] buildings = Building.GetBuildings();
            for (int i = 0; i < buildings.Length; i++)
            {
                string n = buildings[i].Name;
                int q = 0;
                StackPanel box = new StackPanel
                {
                    Height = 100,
                    Width = 170,
                    Children =
                {
                    new TextBlock
                    {
                        Text = string.Format("{0} x{1}", n, q)
                    },
                }
                };
                Border divider = new()
                {
                    BorderBrush = new SolidColorBrush(Colors.Black),
                    BorderThickness = new Thickness(.2),
                };
                ShopBox.Children.Add(box);
                ShopBox.Children.Add(divider);
            }
        }

        public void ClickCookie()
        {
            cookieScore++;
            scoreTB.Text = ((int)cookieScore).ToString();
        }

        private void CookieButton_Click(object sender, RoutedEventArgs e)
        {
            ClickCookie();
        }
    }
}