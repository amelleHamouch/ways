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
    /// Logique d'interaction pour FormularyListPage.xaml
    /// </summary>
    public partial class FormularyListPage : Page
    {


    public FormularyListPage()
        {

            InitializeComponent();
            formularyList.ItemsSource = getFormularies();
            List<Question> items = new List<Question>();


    }

        private void createFormulary(object sender, RoutedEventArgs e)
        {
            string formularyName = formularyNameInput.Text;
            Formulary formulary = new Formulary(formularyName);
        }

        private void getFormularies()
        {

        }

    }
}
