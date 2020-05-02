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
        private TextBox sentenceTxt ;
        private TextBox wrongAnswerTxt;
        private TextBox pointsTxt;
        private TextBox validAnswerTxt;


        public QuizzQuestionsPage(string id)
        {
            InitializeComponent();
            this.idForm = Int32.Parse(id);
            List<Question> result = getQuestions();
            questionList.ItemsSource = result;
            this.DataContext = result;
            sentenceTxt = new TextBox();
            wrongAnswerTxt = new TextBox();
            pointsTxt = new TextBox();
            validAnswerTxt = new TextBox();


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

        private void saveModifiedQuestion(object sender, RoutedEventArgs e)
        {
            infoTextBlock.Text = "";
            bool success = true;

            BindingExpression binding = sentenceTxt.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateSource();
             binding = sentenceTxt.GetBindingExpression(TextBox.TextProperty);
             binding.UpdateSource();
             binding = validAnswerTxt.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateSource();
            binding = wrongAnswerTxt.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateSource();
            //   null pointer ici 
            Question question = new Question(sentenceTxt.Text.ToString(), validAnswerTxt.Text.ToString(), wrongAnswerTxt.Text.ToString(), idForm);
           

            //pointsTxt

            success = question.updateQuestion(question);
            if (!success)
            {
                infoTextBlock.Text += "Echec : Une erreur est survenue lors de la modification\n";
                return;
            }
            else {
                QuizzQuestionsPage page = new QuizzQuestionsPage(idForm.ToString());
                NavigationService.Navigate(page);
            }
           
        }
        private void textChangedEventHandler(object sender, TextChangedEventArgs args)
        {
           
        } 
    }
}
