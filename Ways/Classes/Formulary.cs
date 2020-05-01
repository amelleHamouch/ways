using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using Ways.Classes;
namespace Ways.Classes
{
    class Formulary
    {
        private int idFormulary;
        private string name;
        private List<Question> questionList;

        public int IdFormulary { get => idFormulary; set => idFormulary = value; }
        public string Name { get => name; set => name = value; }
        internal List<Question> QuestionList { get => questionList; set => questionList = value; }

        public Formulary(string name)
        {
            this.Name = name;
            this.idFormulary = initIntoDb();
            
        }

        public Formulary()
        {
            this.QuestionList = new List<Question>();
        }

        public List<Question> getListQuestion()
        {
            return this.QuestionList;
        }

        public void addQuestion(string question, string wrongAnswer, string rightAnswer)
        {
            this.QuestionList.Add(new Question(question, rightAnswer, wrongAnswer, this.IdFormulary));
        }

        public int initIntoDb()
        {
            MySqlConnection sqlCon = Configurations.connection;
            
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            String query = "INSERT INTO `formulary`(`name`) VALUES (@name);SELECT LAST_INSERT_ID();";

            MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);
            sqlCmd.CommandType = System.Data.CommandType.Text;
            sqlCmd.Parameters.AddWithValue("@name", this.name);

            return (Convert.ToInt32(sqlCmd.ExecuteScalar()));
     
        }
      


    }


}

