
using System.Windows;
using System.Windows.Navigation;
using Ways.Vues;

namespace Ways
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new WaysHomePage();
        }

        private void BackToWaysHome(object sender, RoutedEventArgs e)
        {
            Main.Content = new WaysHomePage();
        }
    }
}
