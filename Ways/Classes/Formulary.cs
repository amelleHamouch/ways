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
        private string type;
        private int coef;


        public int IdFormulary { get => idFormulary; set => idFormulary = value; }
        public string Name { get => name; set => name = value; }
        internal List<Question> QuestionList { get => questionList; set => questionList = value; }
        public string Type { get => type; set => type = value; }
        public int Coef { get => coef; set => coef = value; }

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

        public Formulary getFormById(int id)
        {

            Formulary result = new Formulary();
            MySqlConnection sqlCon = Configurations.connection;


            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            String query = "SELECT * FROM formulary WHERE idFormulary = @idFormulary;";
            MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);
            sqlCmd.Parameters.Add(new MySqlParameter("@idFormulary", id));

            sqlCmd.CommandType = CommandType.Text;

            int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
            MySqlDataReader reader = sqlCmd.ExecuteReader();
            while (reader.Read())
            {
                Formulary form = new Formulary();

                {
                    form.IdFormulary = reader.GetInt32(0);
                    form.Name = reader.GetString(1);
                    form.Coef = reader.GetInt32(2);
                    form.Type = reader.GetString(3);

                };
                result= form;
            }
            reader.Close();
            sqlCon.Close();
            return result;
        }

    }


}

