using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

        private void modifyForm(object sender, RoutedEventArgs e)
        {
            string idFormToModify =( ((Button)sender).Tag).ToString();

            QuizzQuestionsPage page = new QuizzQuestionsPage(idFormToModify);

            NavigationService.Navigate(page);


        }

        private List<Formulary> getFormularies()
        {

            List<Formulary> result = new List<Formulary>();
            MySqlConnection sqlCon = Configurations.connection;


            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            String query = "SELECT * FROM formulary ;";
            MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);
            sqlCmd.CommandType = CommandType.Text;

            int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
            MySqlDataReader reader = sqlCmd.ExecuteReader();
            while (reader.Read())
            {
                Formulary form = new Formulary();

                {
                    form.IdFormulary = reader.GetInt32(0);
                    form.Name = reader.GetString(1);

                };
                result.Add(form);
            }
            reader.Close();
            sqlCon.Close();
            return result;
        }



    }
}
