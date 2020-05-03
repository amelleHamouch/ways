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
        public ModifyQuestionWindow(int idQuestion , int idFormulary )
        {
             Id = idQuestion;
            IdFormulary = idFormulary;
            InitializeComponent();
        }
        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            Question question = new Question();
            question.WrongAnswer = wrongAnswerBox.Text;
            question.Id = Id;
            question.IdForm = IdFormulary;
            question.ValidAnswer = goodAnswerBox.Text;
            question.Sentence = sentenceBox.Text;

            question.updateQuestion(question);




         

            Close();

        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
