using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ways.Classes;

namespace Ways.Vues
{
    /// <summary>
    /// Logique d'interaction pour AdminViewStats.xaml
    /// </summary>
    public partial class AdminViewStats : Page
    {
        public AdminViewStats()
        {
            InitializeComponent();
            List<Question> result = getStat(); // On rempli le tableau avec les informations statistiques 
            listStats.ItemsSource = result;
            DataContext = result;
        }

        private List<Question> getStat()
        {
            Question question = new Question();

            List<Question> result = new List<Question>();
            result = question.getStats();

            return result;

        }

    }
}
