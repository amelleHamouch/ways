using System;
using System.Collections.Generic;
using System.Text;

namespace Ways.Classes
{
    class Question
    {
        private int id;
        private string content;
        private string validAnswer;
        private string wrongAnswer;
        private int idForm;

        public int Id { get => id; set => id = value; }
        public string Content { get => content; set => content = value; }
        public string ValidAnswer { get => validAnswer; set => validAnswer = value; }
        public string WrongAnswer { get => wrongAnswer; set => wrongAnswer = value; }
        public int IdForm { get => idForm; set => idForm = value; }

        public Question(string content, string validAnswer, string wrongAnswer, int idForm)
        {
            this.Content = content;
            this.ValidAnswer = validAnswer;
            this.WrongAnswer = wrongAnswer;
            this.IdForm = idForm;
        }

        
    }
}
