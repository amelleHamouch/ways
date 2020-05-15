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
        private string description;


        public int IdFormulary { get => idFormulary; set => idFormulary = value; }
        public string Name { get => name; set => name = value; }
        internal List<Question> QuestionList { get => questionList; set => questionList = value; }
        public string Type { get => type; set => type = value; }
        
        public string Description { get => description; set => description = value; }

        /// <summary>
        /// Constructeur
        /// </summary>
        public Formulary(string name)
        {

            this.Name = name;
            this.idFormulary = initIntoDb();

        }

        /// <summary>
        /// Constructeur
        /// </summary>
        public Formulary()
        {
            this.QuestionList = new List<Question>();
        }

        /// <summary>
        /// Récupération questions du formulaire
        /// </summary>
        public List<Question> getListQuestion()
        {
            return this.QuestionList;
        }

        /// <summary>
        /// Ajouter une question
        /// </summary>
        public void addQuestion(string question, string wrongAnswer, string rightAnswer)
        {
            this.QuestionList.Add(new Question(question, rightAnswer, wrongAnswer, this.IdFormulary));
        }

        /// <summary>
        /// Ajout du Formulaire
        /// </summary>
        public int initIntoDb()
        {
            MySqlConnection sqlCon = Configurations.connection;

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            String query = "INSERT INTO `formulary`(`name`) VALUES (@name);SELECT LAST_INSERT_ID();";

            MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);
            sqlCmd.CommandType = System.Data.CommandType.Text;
            sqlCmd.Parameters.AddWithValue("@name", this.name);
            int id = (Convert.ToInt32(sqlCmd.ExecuteScalar()));
            return id;


        }

        /// <summary>
        /// Formulaire par Id
        /// </summary>
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

            MySqlDataReader reader = sqlCmd.ExecuteReader();
            while (reader.Read())
            {
                Formulary form = new Formulary();

                {
                    form.IdFormulary = reader.GetInt32(0);
                    form.Name = reader.GetString(1);
                    form.Type = reader.GetString(2);
                    form.Description = reader.GetString(3);


                };
                result = form;
            }
            reader.Close();
            sqlCon.Close();
            return result;
        }

    }


}

