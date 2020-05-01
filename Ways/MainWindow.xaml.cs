
using System.Windows;

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


    }
}
