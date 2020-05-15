using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Ways.Classes
{
    class Question
    {
        private int id;
        private string sentence;
        private string validAnswer;
        private string wrongAnswer;
        private int idForm;
        private int points;


        public int Id { get => id; set => id = value; }
        public string ValidAnswer { get => validAnswer; set => validAnswer = value; }
        public string WrongAnswer { get => wrongAnswer; set => wrongAnswer = value; }
        public int IdForm { get => idForm; set => idForm = value; }
        public string Sentence { get => sentence; set => sentence = value; }
        public int Points { get => points; set => points = value; }

        /// <summary>
        /// Constructeur
        /// </summary>
        public Question(string sentence, string validAnswer, string wrongAnswer, int idForm)
        {
            this.Sentence = sentence;
            this.ValidAnswer = validAnswer;
            this.WrongAnswer = wrongAnswer;
            this.IdForm = idForm;
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        public Question()
        {
        }

        /// <summary>
        /// Ajout d'une question à un formulaire
        /// </summary>
        public bool addQuestion(Question newQuestion)
        {
            MySqlConnection sqlCon = Configurations.connection;

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            String query = "INSERT INTO question (`content`,`validAnswer`,`wrongAnswer`,`idForm`,`points` ) VALUES ( @sentence, @validAnswer, @wrongAnswer,@idForm ,@points); SELECT LAST_INSERT_ID();";
            MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);

            sqlCmd.Parameters.Add(new MySqlParameter("@sentence", newQuestion.Sentence));
            sqlCmd.Parameters.Add(new MySqlParameter("@validAnswer", newQuestion.ValidAnswer));
            sqlCmd.Parameters.Add(new MySqlParameter("@wrongAnswer", newQuestion.WrongAnswer));
            // sqlCmd.Parameters.Add(new MySqlParameter("@", newQuestion.Id));
            sqlCmd.Parameters.Add(new MySqlParameter("@idForm", newQuestion.IdForm));
            sqlCmd.Parameters.Add(new MySqlParameter("@points", newQuestion.Points));




            sqlCmd.CommandType = CommandType.Text;
            Id = (Convert.ToInt32(sqlCmd.ExecuteScalar()));
            sqlCon.Close();

            return Id > 0;
        }

        public void updateQuestion(Question updatedQuestion)
        {
            MySqlConnection sqlCon = Configurations.connection;

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            String query = "UPDATE question SET content = @sentence, validAnswer = @validAnswer , wrongAnswer = @wrongAnswer WHERE idQuestion = @idQuestion ; ";
            MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);
            sqlCmd.Parameters.Add(new MySqlParameter("@sentence", updatedQuestion.Sentence));
            sqlCmd.Parameters.Add(new MySqlParameter("@validAnswer", updatedQuestion.ValidAnswer));
            sqlCmd.Parameters.Add(new MySqlParameter("@wrongAnswer", updatedQuestion.WrongAnswer));
            sqlCmd.Parameters.Add(new MySqlParameter("@idQuestion", updatedQuestion.Id));
            sqlCmd.Parameters.Add(new MySqlParameter("@points", updatedQuestion.Points));



            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();

            
        }

        /// <summary>
        /// Select question par Id
        /// </summary>
        public Question getQuestionsById(int id)
        {

            Question result = new Question();
            MySqlConnection sqlCon = Configurations.connection;

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            String query = "SELECT * FROM question where idQuestion = @id ;";
            MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);
            sqlCmd.Parameters.Add(new MySqlParameter("@id", id));

            sqlCmd.CommandType = CommandType.Text;

            int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
            MySqlDataReader reader = sqlCmd.ExecuteReader();
            while (reader.Read())
            {
                Question question = new Question();

                {

                    question.Id = reader.GetInt32(0);
                    question.Sentence = reader.GetString(1);
                    question.ValidAnswer = reader.GetString(2);
                    question.WrongAnswer = reader.GetString(3);
                    question.Points = reader.GetInt32(4);


                };
                result = question;
            }
            reader.Close();
            sqlCon.Close();

            return result;
        }



        /// <summary>
        /// Récupération liste question par Id formulaire
        /// </summary>
        public List<Question> getQuestionsByFormId(int idform)
        {

            List<Question> result = new List<Question>();
            MySqlConnection sqlCon = Configurations.connection;

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            String query = "SELECT * FROM question where idForm = @idForm ;";
            MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);
            sqlCmd.Parameters.Add(new MySqlParameter("@idForm", idform));

            sqlCmd.CommandType = CommandType.Text;
            int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
            MySqlDataReader reader = sqlCmd.ExecuteReader();
            while (reader.Read())
            {
                Question question = new Question();

                {
                    question.Id = reader.GetInt32(0);
                    question.Sentence = reader.GetString(1);
                    question.ValidAnswer = reader.GetString(2);
                    question.WrongAnswer = reader.GetString(3);
                    question.Points = reader.GetInt32(4);

                };
                result.Add(question);
            }
            reader.Close();
            sqlCon.Close();
            return result;
        }

    }

}
