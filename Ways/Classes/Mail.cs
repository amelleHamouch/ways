using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Mail;
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

        public static void sendMainMail(String emailAddress, string pseudoUser, string scoreUser, string orientationUser)
        {

            IDictionary<string, string> emailSettings = getMailSettings();
            MailMessage message = new MailMessage();

            message.From = new MailAddress(emailSettings["mailAddress"]);
            message.To.Add(new MailAddress(emailAddress));

            message.Subject = emailSettings["sujet"];
            message.Subject.Replace("%pseudo%", pseudoUser);
            message.Subject.Replace("%score%", scoreUser);
            message.Subject.Replace("%orientation%", orientationUser);

            message.Body = emailSettings["corps"];
            message.Body.Replace("%pseudo%", pseudoUser);
            message.Body.Replace("%score%", scoreUser);
            message.Body.Replace("%orientation%", orientationUser);

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(emailSettings["mailAddress"], emailSettings["mailPassword"]);

            client.Port = 587;
            client.Host = "smtp.office365.com";
            client.EnableSsl = true;
            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message);
            }
        }
    }
}
