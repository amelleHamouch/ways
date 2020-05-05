using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Ways.Classes
{
    class Mail
    {
        public static void saveMailSettings(string mailAddress, string mailPassword, string corps, string sujet)
        {
            MySqlConnection sqlCon = Configurations.connection;

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            String query = "UPDATE mail SET mailAddress = @mailAddress, mailPassword= @mailPassword, corps = @corps, sujet = @sujet WHERE id = 0;";
            MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);
            sqlCmd.Parameters.Add(new MySqlParameter("@mailAddress", mailAddress));
            sqlCmd.Parameters.Add(new MySqlParameter("@mailPassword", mailPassword));
            sqlCmd.Parameters.Add(new MySqlParameter("@corps", corps));
            sqlCmd.Parameters.Add(new MySqlParameter("@sujet", sujet));

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
        }

        public static IDictionary<string, string> getMailSettings()
        {
            Question result = new Question();
            MySqlConnection sqlCon = Configurations.connection;

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            String query = "SELECT * FROM mail where id = 0 ;";
            MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);
            sqlCmd.CommandType = CommandType.Text;

            int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
            MySqlDataReader reader = sqlCmd.ExecuteReader();
            reader.Read();
            IDictionary<string, string> mailSettings = new Dictionary<string, string>();
            mailSettings.Add("mailAddress", reader.GetString(1));
            mailSettings.Add("mailPassword", reader.GetString(2));
            mailSettings.Add("corps", reader.GetString(3));
            mailSettings.Add("sujet", reader.GetString(4));

       
            reader.Close();
            sqlCon.Close();

            return mailSettings;
        }
    }
}
