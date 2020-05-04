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
    /// Logique d'interaction pour ModifyQuestionWindow.xaml
    /// </summary>
    public partial class ModifyQuestionWindow : Window
    {
        int Id;
        int IdFormulary;
        String ValidAnswer;
        Question question = new Question();
        public ModifyQuestionWindow(int idQuestion , int idFormulary )
        {
         
            InitializeComponent();
            Id = idQuestion;
            IdFormulary = idFormulary;
          
            question = question.getQuestionsById(idQuestion);
            wrongAnswerBox.Text = question.WrongAnswer;
            goodAnswerBox.Text = question.ValidAnswer;
            sentenceBox.Text = question.Sentence;
            pointsBox.Text = question.Points.ToString();



        }
        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {

            if (wrongAnswerBox.Text != null)
            {
                question.WrongAnswer = wrongAnswerBox.Text;
            }
            if (goodAnswerBox.Text != null)
            {
                question.ValidAnswer = goodAnswerBox.Text;
            }
            if (sentenceBox.Text != null)
            {
                question.Sentence = sentenceBox.Text;
            }

            question.updateQuestion(question);

            Close();

        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void sentenceBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
