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
        public static void saveMailSettings(string mailAddress, string mailPassword, string corps, string sujet, string promoSujet, string promoMail)
        {
            MySqlConnection sqlCon = Configurations.connection;

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            String query = "UPDATE mail SET mailAddress = @mailAddress, mailPassword= @mailPassword, corps = @corps, sujet = @sujet, promoSujet = @promoSujet, promoMail = @promoMail WHERE id = 0;";
            MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);
            sqlCmd.Parameters.Add(new MySqlParameter("@mailAddress", mailAddress));
            sqlCmd.Parameters.Add(new MySqlParameter("@mailPassword", mailPassword));
            sqlCmd.Parameters.Add(new MySqlParameter("@corps", corps));
            sqlCmd.Parameters.Add(new MySqlParameter("@sujet", sujet));
            sqlCmd.Parameters.Add(new MySqlParameter("@promoSujet", promoSujet));
            sqlCmd.Parameters.Add(new MySqlParameter("@promoMail", promoMail));


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
            mailSettings.Add("promoSujet", reader.GetString(5));
            mailSettings.Add("promoMail", reader.GetString(6));

       
            reader.Close();
            sqlCon.Close();

            return mailSettings;
        }

        public static void sendMainMail(String emailAddress, string pseudoUser, string scoreUser, string orientationUser)
        {

            IDictionary<string, string> emailSettings = getMailSettings();
            MailMessage message = new MailMessage();
            message.From = new MailAddress(emailSettings["mailAddress"].ToString());
            message.To.Add(new MailAddress(emailAddress));

            string subject = emailSettings["sujet"].ToString();
            // Interdiction d'avoir des retours à la ligne dans les sujets de mails 
            subject = subject.Replace('\r', ' ').Replace('\n', ' ');
            subject = subject.Replace("%pseudo%", pseudoUser);
            subject = subject.Replace("%score%", scoreUser);
            subject = subject.Replace("%orientation%", orientationUser);
            message.Subject = subject;


            message.Body = emailSettings["corps"].ToString();
            message.Body = message.Body.Replace("%pseudo%", pseudoUser);
            message.Body = message.Body.Replace("%score%", scoreUser);
            message.Body = message.Body.Replace("%orientation%", orientationUser);

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
        
        public static void sendPromoMail(String emailAddress, string pseudoUser, string scoreUser, string orientationUser)
        {

            IDictionary<string, string> emailSettings = getMailSettings();
            MailMessage message = new MailMessage();
            message.From = new MailAddress(emailSettings["mailAddress"].ToString());
            message.To.Add(new MailAddress(emailAddress));

            string subject = emailSettings["promoSujet"].ToString();
            // Interdiction d'avoir des retours à la ligne dans les sujets de mails 
            subject = subject.Replace('\r', ' ').Replace('\n', ' ');
            subject = subject.Replace("%pseudo%", pseudoUser);
            subject = subject.Replace("%score%", scoreUser);
            subject = subject.Replace("%orientation%", orientationUser);
            message.Subject = subject;


            message.Body = emailSettings["promoMail"].ToString();
            message.Body = message.Body.Replace("%pseudo%", pseudoUser);
            message.Body = message.Body.Replace("%score%", scoreUser);
            message.Body = message.Body.Replace("%orientation%", orientationUser);

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
