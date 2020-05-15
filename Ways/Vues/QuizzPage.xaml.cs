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
  
    public partial class QuizzPage : Page
    {
        List<Question> questionList;
  
        int actualQuestion = 0;
        int score = 0;
        int formId = 0;
        int orientationScore;
        int userId;
        Formulary form = new Formulary();
       
        public QuizzPage(int id, int playerScore, int userId)
        {
            InitializeComponent();
            questionList = getQuestions(id);
            form = form.getFormById(id);
            formId = id;
            actualQuestion = 0;
            orientationScore = playerScore;
            this.userId = userId;
            displayQuestion();
        }

        public QuizzPage(int id, int userId)
        {
            InitializeComponent();
            questionList = getQuestions(id);
            form = form.getFormById(id);
            formId = id;
            actualQuestion = 0;
            this.userId = userId;
            displayQuestion();
        }

        public QuizzPage()
        {
            InitializeComponent();
        }

        private void displayQuestion()
        {
           
            QuestionLabel.Text = questionList[actualQuestion].Sentence;
            var random = new Random();
            bool inverseQuestion = random.Next(2) == 1;
            rightAnswer.Text = inverseQuestion ? questionList[actualQuestion].ValidAnswer : questionList[actualQuestion].WrongAnswer;
            wrongAnswer.Text = !inverseQuestion ? questionList[actualQuestion].ValidAnswer : questionList[actualQuestion].WrongAnswer;
        }

        private List<Question> getQuestions(int id)
        {
            Question question = new Question();

            List<Question> result = new List<Question>();
            result = question.getQuestionsByFormId(id);

            return result;

        }

        private void Answer(object sender, RoutedEventArgs e)
        {
            var answer = (e.Source as Button).Content.ToString();
            score += answer == questionList[actualQuestion].ValidAnswer ? 1 : -1;
            actualQuestion++;
            if (actualQuestion == questionList.Count)
            {
                if(formId == 1)
                {
                    this.NavigationService.Navigate(new UserOrientationPage(score, this.userId));
                }
                else if(formId == 3)
                {
                    this.NavigationService.Navigate(new WaysHomePage());
                }else
                {
                    this.NavigationService.Navigate(new UserMailPage(orientationScore.ToString(), score, this.userId));
                }
            }
            else
            {
                displayQuestion();
            }
            
        }
    }
}
