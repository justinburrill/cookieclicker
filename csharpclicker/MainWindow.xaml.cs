using System.Windows;

namespace Csharpclicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool _showStats = false;
        public bool ShowStats
        {
            get { return _showStats; }
            set
            {
                _showStats = value;
                Building.ReloadAllText();
            }
        }
        double _cookieScore = 0;
        public double CookieScore
        {
            get
            {
                return _cookieScore;
            }
            set
            {
                _cookieScore = value;
                scoreTB.Text = Math.Round(_cookieScore).ToString();
            }
        }
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


        public void ClickCookie()
        {
            CookieScore++;
        }


        private void AutoClickLoop()
        {
            while (true)
            {
                Thread.Sleep(1000);
                Dispatcher.Invoke(() => { CookieScore += Building.GetCPSFromAllBuildings(buildings); });
            }
        }

        public void UpdateCPS()
        {
            double cps = Building.GetCPSFromAllBuildings(buildings);

            cpsTB.Text = Math.Round(cps, 1).ToString();
        }

        private void CookieButton_Click(object sender, RoutedEventArgs e)
        {
            ClickCookie();
        }

        private void ToggleAdvStatsButton_Click(object sender, RoutedEventArgs e)
        {
            ShowStats = !ShowStats;
        }
    }
}