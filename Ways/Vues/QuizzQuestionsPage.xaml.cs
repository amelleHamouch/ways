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
        int IdForm;
        Formulary form = new Formulary();


        public QuizzQuestionsPage(string id)
        {
            InitializeComponent();
            this.IdForm = Int32.Parse(id);
            List<Question> result = getQuestions();
            questionList.ItemsSource = result;
            DataContext = result;
            form = form.getFormById(IdForm);

            typeFormulaire.Text = form.Type;
            NomFormulaire.Text = form.Name;
            Coefficient.Text = form.Coef.ToString();
           
        }
        public QuizzQuestionsPage()
        {
            InitializeComponent();
          

        }

        private List<Question> getQuestions()
        {
            Question question = new Question();
           
            List<Question> result = new List<Question>();
            result = question.getQuestionsByFormId(IdForm);
            
            return result;

        }

        private void saveModifiedQuestion(object sender, RoutedEventArgs e)
        {
            infoTextBlock.Text = "";
            bool success = true;


            //   null pointer ici 
            //    Question question = new Question(sentenceTxt.Text.ToString(), validAnswerTxt.Text.ToString(), wrongAnswerTxt.Text,idForm);
            Question question = new Question();

             //pointsTxt

        //     success = question.updateQuestion(question);
            if (!success)
            {
                infoTextBlock.Text += "Echec : Une erreur est survenue lors de la modification\n";
                return;
            }
            else {
                QuizzQuestionsPage page = new QuizzQuestionsPage(IdForm.ToString());
                NavigationService.Navigate(page);
            }
           
        }
        private void displayModification(object sender, RoutedEventArgs e)
        {
            string idquestionToModify = (((Button)sender).Tag).ToString();
            int questionId = Int32.Parse(idquestionToModify);
            ModifyQuestionWindow popup = new ModifyQuestionWindow(questionId, IdForm);
            popup.ShowDialog();
            QuizzQuestionsPage page = new QuizzQuestionsPage(IdForm.ToString());
            NavigationService.Navigate(page);
        }


        private void SelectCurrentItem(object sender, KeyboardFocusChangedEventArgs e)
        {
            ListViewItem item = (ListViewItem)sender;
            item.IsSelected = true;

        }

        private void ReturnBtn(object sender, RoutedEventArgs e)
        {
            FormularyListPage page = new FormularyListPage();
            NavigationService.Navigate(page);
        }

     
    }
}
