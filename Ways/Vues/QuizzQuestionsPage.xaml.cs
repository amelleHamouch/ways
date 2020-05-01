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
    /// Logique d'interaction pour QuizzQuestionsPage.xaml
    /// </summary>
    public partial class QuizzQuestionsPage : Page
    {
        int idForm;

        public QuizzQuestionsPage(string id)
        {
            InitializeComponent();
            this.idForm = Int32.Parse(id);
            List<Question> result = getQuestions();
            questionList.ItemsSource = result;
            this.DataContext = result;



        }
        public QuizzQuestionsPage()
        {
            InitializeComponent();
          

        }

        private List<Question> getQuestions()
        {
            Question question = new Question();
           
            List<Question> result = new List<Question>();
            result = question.getQuestionsByFormularyId(idForm);
            
            return result;

        }

    }
}
